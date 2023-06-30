namespace Azure_WebApp
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
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("angularapp_policy", policy =>
                {
                    //policy.WithOrigins("http://localhost:4200").AllowAnyMethod().WithHeaders("Content-Type", "Authorization");
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().WithHeaders("*");
                    //policy.WithOrigins("http://localhost:51237").WithHeaders("Content-Type");

                    //policy.WithOrigins("http://localhost:4200").WithMethods("GET","POST");
                    // policy.AllowAnyOrigin().WithHeaders("*").AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("angularapp_policy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}