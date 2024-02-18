using Domains.Resources;
using EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Hubs;
using VipAssistProject.Models;
using VipAssistProject.Resources;

namespace VipAssistProject
{
    //  FOLLOW THIS FILE STEP BY STEP TO APPLY NOTIFICATION AND ENABLE BROKER IN DATABASE
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            //});
            services.AddDbContext<VipAssistDatabaseContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDatabaseChangeNotificationService, SqlDependencyService>();
            services.AddSignalR();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder => {
                    //URLs are from the front-end (note that they changed
                    //since posting my original question due to scrapping
                    //the original projects and starting over)
                    builder.WithOrigins("https://localhost:44325", "http://vipassisttt.com")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()
                                     .AllowCredentials();
                });
            });
            var emailConfig = config
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllersWithViews();
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
           
           
            
            
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<VipAssistDatabaseContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            ResWebsite.Culture = ResDomains.Culture = new CultureInfo("en");

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddEntityFrameworkStores<VipAssistDatabaseContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/User/LogIn";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;


            });
            services.AddScoped<IServiceCategoriesServices, ClsServiceCategory>();
            services.AddScoped<IServiceMediasServices, ClsServicesMedia>();
            services.AddScoped<IServicesServices, ClsServices>();
            services.AddScoped<ISliderImagesServices, ClsSliderImages>();

            services.AddScoped<IClsSalesInvoice, ClsSalesInvoice>();
            services.AddScoped<IClsSalesInvoiceServices, ClsSalesInvoiceServices>();
            services.AddScoped<IClsErrorLog, ClsErrorLog>();
            services.AddScoped<IGetChat, ClsGetChat>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
        
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime LifeTime, IDatabaseChangeNotificationService notificationService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            var supportedCultures = new[] { "en-US", "ar-EG", "fr" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
            });
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(

                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}");


                endpoints.MapControllerRoute(

                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();



            });
           
        }
        public static bool ChangeLanguage()
        {
            if (ResWebsite.Culture.Name == "en")
                ResWebsite.Culture = new CultureInfo("ar");
            else
                ResWebsite.Culture = new CultureInfo("en");

            return true;
        }
    }
}
