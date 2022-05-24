using ELearning.DAL.Models;
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
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.DAL;
using ELearning.BLL;
using ELearning.DAL.Interface;
using ELearning.BLL.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ELearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ELearningDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserInformation, IdentityRole>()
                .AddEntityFrameworkStores<ELearningDBContext>()
                .AddDefaultTokenProviders();



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience =Configuration["JWT:ValidAudience"],
                     ValidIssuer = Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                 };
             });

            services.AddScoped<IOperationDAL<Project>, ProjectDAL>();
            services.AddScoped<IOperationBLL<Project>, ProjectBLL>();
            services.AddScoped<IOperationDAL<Documentation>, DocumentationDAL>();
            services.AddScoped<IOperationBLL<Documentation>, DocumentationBLL>();
            services.AddScoped<IPersonDAL<Student>, StudentDAL>();
            services.AddScoped<IPersonBLL<Student>, StudentBLL>();
            services.AddScoped<IPersonDAL<Faculty>, FacultyDAL>();
            services.AddScoped<IPersonBLL<Faculty>, FacultyBLL>();
            services.AddScoped<IAssignedDAL, AssignedDAL>();
            services.AddScoped<IAssignedBLL, AssignedBLL>();
            services.AddScoped<IOperationDAL<Calender>, CalenderDAL>();
            services.AddScoped<IOperationBLL<Calender>, CalenderBLL>();
            services.AddScoped<IOperationDAL<Articles>, ArticleDAL>();
            services.AddScoped<IOperationBLL<Articles>, ArticleBLL>();
            services.AddScoped<IUserDAL<UserInformation>, UserDAL>();
            services.AddScoped<IUserBLL<UserInformation>, UserBLL>();
            services.AddScoped<IChatDAL, ChatDAL>();
            services.AddScoped<IChatBLL, ChatBLL>();

            
            services.AddControllers();
           
            
           

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ELearning v1"));
            }


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
