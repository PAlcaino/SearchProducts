namespace ProductsSearch.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using ProductsSearch.Web.Services;
    using System;
    using System.Net.Http;

    /// <summary>
    /// Startup Project class
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configure all required services for Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(Configuration["ApiSettings:BaseUrl"])
            });

            var apisettings = new ApiSettings();
            Configuration.Bind("ApiSettings", apisettings);

            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            services.AddScoped<IProductsService, ProductsService>();
        }

        /// <summary>
        /// Configure application settings
        /// </summary>
        /// <param name="services"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
