using Backend.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sandbox.Backend.DataAccess;
using Sandbox.Messaging;
using Sandbox.RestApi.Consumer;

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
			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder => { builder.WithOrigins("http://localhost:4200", "https://localhost:4200"); });
			});

			services.SetupRabbitMq<DataCollectionConsumer>()
				.AddScoped<ICsvLogic, CsvLogic>()
				.AddScoped<ISampleDataAccess, SampleDataAccess>()
				.AddScoped<ISampleDbContext, SampleDbContext>()
				.AddScoped<ISampleDbContext, SampleDbContext>()
				.AddScoped<IMongoDbDataAccess, MongoDbDataAccess>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
