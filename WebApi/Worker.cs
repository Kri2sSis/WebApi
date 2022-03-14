using WebApi.Core;

public class Worker : BackgroundService
{

    public IServiceProvider Service { get; }

    public Worker(IServiceProvider service)
    {
        Service = service;
    }



    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using(var scope = Service.CreateScope())
        {
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IUsersServices>();

            await scopedProcessingService.CreatUserTele2();
        }
    }
}