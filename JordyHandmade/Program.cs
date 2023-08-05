namespace JordyHandmade
{
    using Microsoft.EntityFrameworkCore;       
    using Microsoft.AspNetCore.Identity;

    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.Infrastructure.ModelBinders;
    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Web.Infrastructure.Extensions;
    using static JordyHandmade.Common.GeneralApplicationConstants;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
                        
            string connectionString = 
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<JordyHandmadeDbContext>(options =>
                options.UseSqlServer(connectionString));                        

            builder.Services.AddDefaultIdentity<Customer>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<JordyHandmadeDbContext>();

            builder.Services.AddAppServices(typeof(IProductService));
            
            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options => 
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            WebApplication app = builder.Build();
                        
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator(AdminEmail);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapDefaultControllerRoute();

            app.MapRazorPages();

            app.Run();
        }
    }
}