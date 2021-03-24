using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;// is is added for the redirector on line 61
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Microsoft.EntityFrameworkCore;
using BusinessLogic;

namespace memesaver
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// get the connection string from the user secrets
			string connectionString = Configuration.GetConnectionString("memeDb");

			// add the Db context
			services.AddDbContext<memeSaverContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
			services.AddScoped<UserMethods>();
			services.AddScoped<MemeSaverRepo>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "memesaver", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "memesaver v1"));
			}

			// allows to use the static JS pages
			app.UseStatusCodePages();

			app.UseHttpsRedirection();

			// use this to  redirect to the index HTML for any random path
			app.UseRewriter(new RewriteOptions()
				.AddRedirect("^$", "index.html"));

			// use the .js static files (find out what 'static' means)
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
