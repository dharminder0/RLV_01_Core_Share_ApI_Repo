namespace Core.BackgroundService {
    public interface IScheduledTask {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}