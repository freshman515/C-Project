
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;
using MyToDo.Api.Context.Repository;
using MyToDo.Api.Extension;
using MyToDo.Api.Service;

namespace MyToDo.Api {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //配置sqlite第二步
            builder.Services.AddDbContext<MyToDoContext>(options => {
                var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
                options.UseSqlite(connectionString);
            }).AddUnitOfWork<MyToDoContext>()
            .AddCustomRepository<ToDo, ToDoRepository>()
            .AddCustomRepository<Memo, MemoRepository>()
            .AddCustomRepository<User, UserRepository>();

            ///配置AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfile());
            });
            builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
            ///服务注册
            builder.Services.AddTransient<IToDoService, ToDoService>();
            builder.Services.AddTransient<IMemoService, MemoService>();
            builder.Services.AddTransient<ILoginService,LoginService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
         
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
