using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Text.Json.Serialization;

namespace DBFirstApproach
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
            builder.Services.AddDbContext<AspnetwebapidbContext>();
            builder.Services.AddScoped<IDataAccessService, EFCoreDataAccess>();
            builder.Services.AddCors(options=>
            {
                options.AddPolicy("angularapp_policy",policy =>
                {
                    policy.WithOrigins("http://localhost:4200").WithHeaders("*");
                    policy.WithOrigins("http://localhost:51237").WithHeaders("Content-Type");

                    //policy.WithOrigins("http://localhost:4200").WithMethods("GET","POST");
                   // policy.AllowAnyOrigin().WithHeaders("*").AllowAnyMethod();
                });
            });
                builder.Services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            //when ever any controllers needs the service share the EfCoreDataAccess to all the controllers instance

            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 1);//what should be the default api version
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;



                //pass "api-version" in HTTP request header
                x.ApiVersionReader = new HeaderApiVersionReader("customer-api-version");//if this is uncomentted you have to give your version numbers as a header and parameters wont work
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            //app.UseCors("angularapp_policy");
            app.UseCors();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}