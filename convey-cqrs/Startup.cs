using Convey;
using Convey.CQRS.Commands;
using Convey.Metrics.AppMetrics;
using convey_cqrs.Services.Item;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace convey_microservice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            
            services.AddConvey();
            ConfigureConvey(services);
            services.AddControllers();
        }

        private static void ConfigureConvey(IServiceCollection services)
        {
            var builder = ConveyBuilder
                .Create(services)
                .AddCommandHandlers()
                .AddInMemoryCommandDispatcher()
                .AddMetrics();

            builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
}