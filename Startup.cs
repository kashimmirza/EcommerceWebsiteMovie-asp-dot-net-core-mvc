

//namespace EcommerceWebsiteMovie
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            configuration = configuration;
//        }
//        public IConfiguration Configuartion { get; }
//        public void ConfigureServices(IServiceCollection services)
//        {

//            services.AddDbContext<AppDbContext>(options =>
//            options.UseSqlServer(Configuartion.GetConnectionString("DefaultConnection")));

//            services.AddControllersWithViews();
//        }
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync("Hello World!");
//            });
//        }
//    }
//}


using Microsoft.EntityFrameworkCore;
using EcommerceWebsiteMovie.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using EcommerceWebsiteMovie.Data.Services;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
       
    Configuration= configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        // Replace 'YourConnectionString' with your actual connection string
        services.AddDbContext<AppDbContext>(options =>

            options.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=eticketdatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        services.AddSession();
        services.AddMvc();
        // Other service configurations
        services.AddControllersWithViews();
        services.AddScoped<IActorsService, ActorService>();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        if (env.IsDevelopment())
        {   
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");
        });
        app.UseSession();
        
        appDbInitializer.Seed(app);
      }

    //Other methods
}
