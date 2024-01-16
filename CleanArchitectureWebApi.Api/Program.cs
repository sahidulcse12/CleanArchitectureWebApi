using CleanArchitectureWebApi.Application;
using CleanArchitectureWebApi.Infrastructure;

namespace CleanArchitectureWebApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //add layer dependency

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureService(builder.Configuration);

            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
