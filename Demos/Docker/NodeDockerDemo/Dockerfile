# this is the backbone image for this application
FROM node:12-alpine

# this downloads the applications you need for the app
RUN apk add --no-cache python g++ make

# changes the working directory to the app dit inside the container
WORKDIR /app

# copies allthe files from outside the container to inside
COPY . .

# run the command to instal dependencies
RUN yarn install --production

# entrypoint to start the application
CMD ["node", "src/index.js"]