using System.Reflection;
using System.Text;
using CourseWork.Application.Services;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CourseWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var issuer = builder.Configuration.GetValue<string>("AuthOptions:Issuer");
            var audience = builder.Configuration.GetValue<string>("AuthOptions:Audience");
            var key = builder.Configuration.GetValue<string>("AuthOptions:Key");
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<CharityDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChatService, ChatService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IMessageService, MessagesService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserProfileService, UserProfileService>();
            builder.Services.AddSingleton(TimeProvider.System);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddExceptionHandler<ExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http, In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Авторизация через JWT."
                });
    
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });



            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CharityDBContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
