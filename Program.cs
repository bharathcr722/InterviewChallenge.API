using InterviewChallenge.API.Behaviour.Bakery;
using InterviewChallenge.API.Behaviour.Orders;
using InterviewChallenge.API.DataAccess;
using InterviewChallenge.API.DataAccess.Bakery;
using InterviewChallenge.API.DataAccess.Orders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InterviewChallenge.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            ConfigureSecurityService(builder);
            ConfigureService(builder.Services);
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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<DBService>();
            services.AddScoped<IBakeryDataAccess, BakeryDataAccess>();
            services.AddTransient<IBakeryBehaviour, BakeryBehaviour>();
            
            services.AddScoped<IOrdersDataAccess, OrdersDataAccess>();
            services.AddTransient<IOrdersBehaviour, OrdersBehaviour>();
        }
        public static void ConfigureSecurityService(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
                    };
                });
            builder.Services.AddAuthorization();
        }
    }
}
