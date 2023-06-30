using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace VersionedAPI
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);//what should be the default api version
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;



                //pass "api-version" in HTTP request header
                //x.ApiVersionReader = new HeaderApiVersionReader("api-version");//if this is uncomenttedyou have to give your version numbers as a header and parameters wont work
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                "Training. Versioned API Learning");
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}