#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#download the verified SDK image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base 
# create a working directory
WORKDIR /app	
# expose a http port
EXPOSE 80		
# expose a https port (the secure one)
EXPOSE 443		

#download the verified SDK image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build 
# create a work directory
WORKDIR /src		
# copy .csproj file in to the current working directory
COPY ["WebApplication1.csproj", ""] 
# restore the project
RUN dotnet restore "./WebApplication1.csproj" 
# copy thre reset of the files from the current file into the containers working dir.
COPY . .	
# set yet a new working directory 
WORKDIR "/src/."
#build the app and place .exe into /app/build
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build 

# using the same SDK as above
FROM build AS publish 
# publish into /app/publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish 

# same as above
FROM base AS final 
WORKDIR /app 
# copy publish .exe into working directory.
COPY --from=publish /app/publish . 
# set the start point of the app.
ENTRYPOINT ["dotnet", "WebApplication1.dll"] 