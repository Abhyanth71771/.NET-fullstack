namespace DemoWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //dependancy injection pattern ,reading configs from here
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //middlewares
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();//final call to build (ready to move)
            //to here
            // Configure the HTTP request pipeline.
            //this is used to add customization to the house,adding middelwares
            if (app.Environment.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();//everything is set up and ready to accesp requests
        }
    }
}