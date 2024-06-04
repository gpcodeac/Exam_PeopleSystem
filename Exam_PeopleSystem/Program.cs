using PeopleSystem.Database.Extensions;
using PeopleSystem.BusinessLogic.Extensions;

using Exam_PeopleSystem.Extensions;

namespace Exam_PeopleSystem
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
            
            builder.Services.AddSwaggerConfiguration();
            builder.Services.AddJwtConfiguration(builder.Configuration);

            builder.Services.AddBusinessLogicServices();
            builder.Services.AddDatabaseServices(builder.Configuration);  //should i pass whole configuration or just the connection string?


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
