
using Microsoft.EntityFrameworkCore;
using UserAPI_Tanuka.Context;
using UserAPI_Tanuka.Logging;
using UserAPI_Tanuka.Repository;
using UserAPI_Tanuka.Services;


namespace UserAPI_Tanuka
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            string? connectionStr = builder.Configuration.GetConnectionString("userConnectionString");
            builder.Services.AddDbContext<UserDbContext>(o => o.UseSqlServer(connectionStr));
            builder.Services.AddSingleton<UserLogger>();

            builder.Services.AddCors();
            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(u => u
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
