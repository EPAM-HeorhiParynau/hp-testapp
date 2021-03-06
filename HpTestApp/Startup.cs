﻿using System;

using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ServiceStation.WebUI.Filters;

using Swashbuckle.AspNetCore.Swagger;

namespace HpTestApp
{
    public class Startup
    {
	    private readonly IServiceProvider serviceProvider;

	    public Startup(IConfiguration configuration)
	    {
		    Configuration = configuration;

			//new AzureTableStorageLogger().InsertEntity(new TableLogMessage { Timestamp = DateTime.Now, Message = "AppStart" });
			//new AzureFileStorageLogger().InsertEntity(new FileLogMessagecs { Timestamp = DateTime.Now, Text = "AppStart" });

	        //new AzureBlobStorageLogger();
	    }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
	        });

	        services.AddSingleton<TelemetryClient>();
	        services.AddSingleton<AiHanleErrorAttribute>();

	        services.AddSwaggerGen(c =>
		        {
			        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
		        });

			services.AddMvc(options => { options.Filters.Add(new AiHanleErrorAttribute(new TelemetryClient())); })
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

	        // Enable middleware to serve generated Swagger as a JSON endpoint.
	        app.UseSwagger();

	        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
	        // specifying the Swagger JSON endpoint.
	        app.UseSwaggerUI(c =>
		        {
			        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
		        });


			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

	        //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
	        //loggerFactory.AddDebug();
	        //loggerFactory.AddLog4Net(Configuration.GetValue<string>("Log4NetConfigFile:Name"));
		}
    }
}
