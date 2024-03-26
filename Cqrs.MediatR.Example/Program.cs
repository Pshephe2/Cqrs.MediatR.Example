
using Cqrs.MediatR.Example.Behaviors;
using Cqrs.MediatR.Example.Data;
using MediatR;

namespace Cqrs.MediatR.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddSingleton(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<FakeDataFactory>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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