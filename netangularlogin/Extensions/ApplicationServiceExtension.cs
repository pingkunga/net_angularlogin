using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using netangularlogin.Core.Entities;
using netangularlogin.Infrastructure;

namespace netangularlogin.Extensions{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppIdentityDbContext>(option =>
            {
                //จาก appsetting.json ให้เอา Connection มาใช้
                option.UseSqlite(config.GetConnectionString("Connection"));
            });

            services.AddIdentity<Users, IdentityRole>(opt =>
            {
                // add identity option                 
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;

            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddUserManager<UserManager<Users>>()
            .AddSignInManager<SignInManager<Users>>()
            .AddDefaultTokenProviders();

            services.AddCors(Opt =>
            {

                Opt.AddDefaultPolicy(opt =>
                    {
                    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

                // Opt.AddDefaultPolicy("CorsPolicy", policy =>
                //  {
                //      policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200/");
                //  });
            });

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            /*
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        // ValidateIssuer = true,
                        // ValidateAudience = true,
                        // ValidAudience = config["Jwt:Site"],
                        // ValidIssuer = config["Jwt:Site"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SigningKey"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                options.AddPolicy("VipOnly", policy => policy.RequireRole("VIP"));
            });

            services.AddScoped<ITokenService, TokenService>();
            */
            return services;

        }
    }
}