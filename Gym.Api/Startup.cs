using Gestor.Domain.Middlewares;
using Gym.Domain.Middlewares;
using Gym.Iot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Gym.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(
                    options => options.Filters.Add<CustomExceptionFilter>()
            ).AddNewtonsoftJson(
                opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );
            services.Configure<ApiBehaviorOptions>(
                options => options.InvalidModelStateResponseFactory = ctx => new ValidationProblemDetailResult()
            );
            services.AddInfraestructure(_configuration);
            services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gym api", Version = "v1" })
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ErrorResponseMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
