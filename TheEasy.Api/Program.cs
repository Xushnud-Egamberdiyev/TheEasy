
using Microsoft.EntityFrameworkCore;
using TheEasy.Api.Middlewares;
using TheEasy.Data.DbContexs;
using TheEasy.Data.IRepositories;
using TheEasy.Data.Repositories;
using TheEasy.Services.Interfaces;
using TheEasy.Services.Mappers;
using TheEasy.Services.Services;

namespace TheEasy.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Middleware
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();
                
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
