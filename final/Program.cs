using italk.BL.Managers.AccManager;
using italk.BL.Managers.LanguageManager;
using italk.BL.Managers.ReservationManager;
using italk.BL.Profiles;
using italk.DAL.Data.Context;
using italk.DAL.Data.Models;
using italk.DAL.Repos.Instructors;
using italk.DAL.Repos.Languages;
using italk.DAL.Repos.Reservations;
using italk.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));


            #region CORS

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", cors =>
                {
                    cors.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            #endregion
            builder.Services.AddAutoMapper(typeof(StudentProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ReservationProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(InstructorProfile).Assembly);

            var connectionString = builder.Configuration.GetConnectionString("ConString");
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Log => Debug.WriteLine(Log) , LogLevel.Information).EnableSensitiveDataLogging());

            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<ILanguageRepo, LanguageRepo>();
            builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAccManager, AccManager>();
            builder.Services.AddScoped<ILanguageManager, LanguageManager>();
            builder.Services.AddScoped<IReservationManager, ReservationManager>();


            #region Identity Manager

            builder.Services.AddIdentity<BaseModel, IdentityRole<int>>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<Context>();

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                    var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                    var key = new SymmetricSecurityKey(keyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
            });
            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Instructor", policy => policy
                    .RequireClaim(ClaimTypes.Role, "instructor")
                    .RequireClaim(ClaimTypes.NameIdentifier));

                options.AddPolicy("Student", policy => policy
                    .RequireClaim(ClaimTypes.Role, "student")
                    .RequireClaim(ClaimTypes.NameIdentifier));
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}