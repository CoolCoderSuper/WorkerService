namespace WorkerService;
public class Worker : BackgroundService
{
    private readonly ActionService _service;

    public Worker(ActionService service)
    {
        _service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Run(() => _service.Run("Worker"), stoppingToken);
        }
    }
}