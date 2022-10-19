using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApi
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
            services.AddDbContext<ApplicationDbContext>();

            //Add Identity

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = false;
                //Thiet lap Password
                options.Password.RequireDigit = false; //Khong bat buoc co so
                options.Password.RequireLowercase = false; //Khong bat buoc co lowercase
                options.Password.RequireNonAlphanumeric = false; //Khong bat buoc ky tu dac biet
                options.Password.RequireUppercase = false; //Khong bat buoc co uppercase
                options.Password.RequiredLength = 3; //So ky tu toi da
                options.Password.RequiredUniqueChars = 1; //So ky tu rieng biet
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicApi", Version = "v1" });
            });





            //services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();


            //Declare DI
            //services.AddTransient<UserManager<User>, UserManager<User>>();
            //services.AddTransient<SignInManager<User>, SignInManager<User>>();
            //services.AddTransient<RoleManager<User>, RoleManager<User>>();


            services.AddTransient<AuthenticationDAO>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();








            var secretKey = Configuration["JWT:Key"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Cap Token
                        ValidateIssuer = true,
                        //ValidateAudience = false,

                        //Sinh Token
                        ValidIssuer = Configuration["JWT:Issuer"],
                        //ValidAudience = Configuration["JWT:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes)
                    };
                });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicApi v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
