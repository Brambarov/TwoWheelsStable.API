
using api.Data;
using api.Repositories;
using api.Repositories.Contracts;
using api.Services;
using api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myCorsPolicy = "myCorsPolicy";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IMotorcyclesRepository, MotorcyclesRepository>();
            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
            builder.Services.AddScoped<IMotorcyclesService, MotorcyclesService>();
            builder.Services.AddScoped<ICommentsService, CommentsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(myCorsPolicy);

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
