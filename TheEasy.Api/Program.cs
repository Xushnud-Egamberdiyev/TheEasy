using Serilog;
using TheEasy.Api.Extensions;
using TheEasy.Api.Middlewares;
using TheEasy.Data.DbContexs;
using TheEasy.Services.Mappers;

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

            builder.Services.AddHttpContextAccessor();


            //Database configuration
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddCustomService();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //logger
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);


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
