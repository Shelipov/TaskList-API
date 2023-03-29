using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskList.BLL.Interface.Services;
using TaskList.BLL.Services;
using TaskList.DAL.DataBase.Context;
using TaskList.DAL.DataBase.Repositories;
using TaskList.DAL.Interface.Repositories;
using TaskList.Sheduler;
using TaskList.Sheduler.Intefaces;
using TaskList.Sheduler.Services;

namespace TaskList_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskListContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICurrentTaskListRepository, CurrentTaskListRepository>();
            services.AddScoped<ICurrentTaskRepository, CurrentTaskRepository>();
            services.AddScoped<IUserCurrentTaskListRepository, UserCurrentTaskListRepository>();
            services.AddScoped<ITaskListService, TaskListService>(); 
            services.AddScoped<IUserTaskListService, UserTaskListService>();
            services.AddScoped<ITaskListShedulerService, TaskListShedulerService>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddHostedService<TaskListBackgroundService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
