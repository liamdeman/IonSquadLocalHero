using System;
using System.Security.Claims;
using System.Net.Http;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Proj2Aalst_G3.Data;
using Proj2Aalst_G3.Data.Repositories;
using Proj2Aalst_G3.Filters;
using Proj2Aalst_G3.Models.Domain;
using Proj2Aalst_G3.Models.ViewModels;
using Proj2Aalst_G3.Services.DiscordBot;
using Proj2Aalst_G3.Services.Matchmaking;
using Proj2Aalst_G3.Services.Toornament;
using Proj2Aalst_G3.Validators;

namespace Proj2Aalst_G3
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
            services.AddControllersWithViews(options =>
                {
                    options.Filters.Add<PageHitActionFilter>();
                })
                .AddFluentValidation();
            services.AddAutoMapper(typeof(ToornamentProfile));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<Proj2Aalst_G3DataInitializer>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/signin";
                options.LogoutPath = "/signout";
            }).AddDiscord(options =>
            {
                options.ClientId = Configuration["Discord:ClientId"];
                options.ClientSecret = Configuration["Discord:ClientSecret"];
                options.Scope.Add("email");
                options.Scope.Add("guilds.join");
            });

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "user"));

            });

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IStatisticsDataRepository, StatisticsDataRepository>();
            services.AddScoped<IBlogpostRepository, BlogpostRepository>();

            services.AddTransient<IValidator<TournamentViewModels.Edit>, TournamentViewModelValidator>();
            
            services.AddScoped<MatchmakingService>();
            services.AddSingleton<DiscordService>(sp =>
                new DiscordService(Configuration["Discord:BotToken"],
                    Configuration["Discord:Prefix"],
                    Configuration["Discord:LfgChannelName"],
                    Configuration["Discord:BlogpostChannelName"],
                    services, sp.GetRequiredService<IServiceScopeFactory>()));

            services.Configure<ToornamentApiSettings>(Configuration.GetSection(ToornamentApiSettings.Toornament));
            services.AddHttpClient<IToornamentService, ToornamentService>(c =>
            {
                c.BaseAddress = new Uri("https://api.toornament.com/");
                c.DefaultRequestHeaders.Add("X-Api-Key", Configuration["Toornament:ApiKey"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            Proj2Aalst_G3DataInitializer proj2Aalst_G3DataInitializer, DiscordService discordBot,
            UserManager<ApplicationUser> usermanager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                proj2Aalst_G3DataInitializer.InitializeData();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                proj2Aalst_G3DataInitializer.InitializeDataProd();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            if (Convert.ToBoolean(Configuration["useDiscordBot"]))
                discordBot.StartBot();
        }
    }
}