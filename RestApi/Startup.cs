using Backend.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sandbox.Backend.DataAccess;
using Sandbox.Messaging;
using Sandbox.RestApi.Consumer;
using Sandbox.RestApi.SignalR;
using Serilog;

namespace Sandbox.RestApi
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
			services.AddSignalR();
			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.WithOrigins("http://localhost:4200")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials());
			});

			services.AddScoped<ICsvLogic, CsvLogic>()
				.AddScoped<ISampleDataAccess, SampleDataAccess>()
				.AddScoped<ISampleDbContext, SampleDbContext>()
				.AddScoped<ISampleDbContext, SampleDbContext>()
				.AddScoped<IMongoDbDataAccess, MongoDbDataAccess>()
				.SetupRabbitMq();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Write streamlined request completion events, instead of the more verbose ones from the framework.
            // To use the default framework request logging instead, remove this line and set the "Microsoft"
            // level in appsettings.json to "Information".
            app.UseSerilogRequestLogging();

            app.UseRouting();

			app.UseCors("CorsPolicy");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<BasicHub>("/trigger");
				endpoints.MapControllers();
			});

			SharedHubContext = app.ApplicationServices.GetService<IHubContext<BasicHub>>();
		}

        public static IHubContext<BasicHub> SharedHubContext { get; set; }
	}
}
