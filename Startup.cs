using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // ...
                    ValidateIssuer = true,
                    ValidIssuer = "RestaurantPOS",
                    ValidateAudience = true,
                    ValidAudience = "RestaurantPOS",
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RestaurantPOS"))
                };
            });
        // ...
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireClaim("User"));
            });
        }
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ...
        app.UseAuthentication();
        app.UseAuthorization();
        // ...
    }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void Services(IServiceCollection services)
    {
        services.AddDbContext<RestaurantDbContext>(options =>
        {
            options.UseSqlite("Data Source=restaurant.db");
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "RestaurantPOS",
                    ValidateAudience = true,
                    ValidAudience = "RestaurantPOS",
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RestaurantPOS"))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
            options.AddPolicy("UserOnly", policy => policy.RequireClaim("User"));
        });
    }
}