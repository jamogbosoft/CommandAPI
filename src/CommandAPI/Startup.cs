using CommandAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommandContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration.GetConnectionString("API_Conn"));
            });

            _ = services.AddControllers(); 
            // _ = services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
            _ = services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseRouting();

            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapControllers();
              });
        }
    }
}
