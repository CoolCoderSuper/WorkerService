namespace WorkerService;
public class ActionService
{
    private DateTime _lastRun = DateTime.Now;

    public void Run(string action, int delay = 5)
    {
        if (DateTime.Now.Subtract(_lastRun).TotalSeconds > delay)
        {
            _lastRun = DateTime.Now;
            Console.WriteLine($"{action} called at {_lastRun}");
        }
    }
}