using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TwoWheelsStable.API.Data;
using TwoWheelsStable.API.Helpers.Configs;
using TwoWheelsStable.API.Middleware;
using TwoWheelsStable.API.Models;
using TwoWheelsStable.API.Repositories;
using TwoWheelsStable.API.Repositories.Contracts;
using TwoWheelsStable.API.Services;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myCorsPolicy = "myCorsPolicy";
            var connectionString = string.Empty;
            var jwtSigningKey = string.Empty;
            var apiNinjasKey = string.Empty;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myCorsPolicy,
                                policy =>
                                {
                                    policy.AllowAnyOrigin();
                                    policy.AllowAnyMethod();
                                    policy.AllowAnyHeader();
                                });
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "TwoWheelsStableAPI", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter a valid token.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });


            /*if (builder.Environment.IsProduction())
            {
                var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL");
                var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
                var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
                var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

                var credential = new ClientSecretCredential(keyVaultDirectoryId.Value.ToString(),
                                                            keyVaultClientId.Value.ToString(),
                                                            keyVaultClientSecret.Value.ToString());

                builder.Configuration.AddAzureKeyVault(keyVaultURL.Value.ToString(),
                                                       keyVaultClientId.Value.ToString(),
                                                       keyVaultClientSecret.Value.ToString(),
                                                       new DefaultKeyVaultSecretManager());

                var client = new SecretClient(new Uri(keyVaultURL.Value.ToString()), credential);

                connectionString = client.GetSecret("AzureConnection").Value.Value.ToString();
                jwtSigningKey = client.GetSecret("JWTSigningKey").Value.Value.ToString();
                apiNinjasKey = client.GetSecret("APINinjasKey").Value.Value.ToString();
            }*/

            if (builder.Environment.IsDevelopment())
            {
                //connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                connectionString = builder.Configuration.GetConnectionString("AzureConnection");
                jwtSigningKey = Environment.GetEnvironmentVariable("JWT_SIGNING_KEY");
                apiNinjasKey = Environment.GetEnvironmentVariable("APININJAS_KEY");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                //options.Password.RequiredLength = 12;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKey)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddHttpClient();

            builder.Services.AddSingleton(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKey)));
            builder.Services.AddSingleton(new APINinjasConfig { APIKey = apiNinjasKey });

            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IRefreshTokensService, RefreshTokensService>();
            builder.Services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
            builder.Services.AddScoped<IMotorcyclesService, MotorcyclesService>();
            builder.Services.AddScoped<IMotorcyclesRepository, MotorcyclesRepository>();
            builder.Services.AddScoped<IImagesService, ImagesService>();
            builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
            builder.Services.AddScoped<ISpecsService, SpecsService>();
            builder.Services.AddScoped<ISpecsRepository, SpecsRepository>();
            builder.Services.AddScoped<IJobsService, JobsService>();
            builder.Services.AddScoped<IJobsRepository, JobsRepository>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();
            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
            builder.Services.AddScoped<IAPINinjasService, APINinjasService>();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            /*if (app.Environment.IsDevelopment())
            {*/
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TwoWheelsStableAPI v1");
            });
            /*}*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(myCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
