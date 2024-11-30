using System.Reflection;
using CourseWork.Application.Services;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CharityDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChatService, ChatService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            
            builder.Services.AddControllers();
            builder.Services.AddExceptionHandler<ExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


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

            app.UseAuthorization();

            app.UseExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
