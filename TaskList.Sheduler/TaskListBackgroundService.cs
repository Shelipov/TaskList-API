using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskList.Sheduler.Intefaces;
using TaskList.Sheduler.Options;

namespace TaskList.Sheduler
{
    public class TaskListBackgroundService : BackgroundService
    {
        private readonly IOptions<SchedulerOptions> options;
        private readonly IServiceProvider services;
        private readonly ILogger<TaskListBackgroundService> logger;

        public TaskListBackgroundService(ILogger<TaskListBackgroundService> logger,
            IOptions<SchedulerOptions> options,
            IServiceProvider services)
        {
            this.logger = logger;
            this.options = options;
            this.services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Task List scheduler running at: {time}", DateTime.UtcNow);

                using (var scope = services.CreateScope())
                {
                    var schedulerDataSet = scope.ServiceProvider.GetRequiredService<ITaskListShedulerService>();

                    await schedulerDataSet.Exequte();
                }

                logger.LogInformation("Task List scheduler completed at: {time}", DateTime.UtcNow);
                await Task.Delay(options.Value.Interval, stoppingToken);
            }
        }
    }
}