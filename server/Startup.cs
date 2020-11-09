using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatDemo {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (opt => {
                opt.AddPolicy ("CorsPolicy", policy => {
                    policy
                        .AllowAnyOrigin ()
                        .AllowAnyMethod ()
                        .AllowAnyHeader ();
                });
            });

            services.AddControllers ();

            services.AddTransient<DataContext> ();

            services.AddDbContext<DataContext> (opt => {
                opt.UseSqlite (Configuration.GetConnectionString ("DefaultConnection"));
            });

            services.Configure<IISOptions> (options => {
                options.AutomaticAuthentication = false;
            });
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseDefaultFiles ();
            app.UseStaticFiles ();

            app.UseRouting ();

            app.UseCors ("CorsPolicy");

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();

                endpoints.MapFallbackToController ("Index", "Fallback");
            });
        }
    }
}