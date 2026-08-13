//Gustavo Decker Couto
namespace AcademiaDoZe.Domain.Common;

public class Result<T>
{
    private readonly List<Notification> _notifications = new();

    public T? Value { get; private set; }
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
    public bool IsSuccess => _notifications.Count == 0;
    public bool IsFailure => !IsSuccess;

    private Result(T value)
    {
        Value = value;
    }

    private Result(IEnumerable<Notification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(IEnumerable<Notification> notifications) => new(notifications);

    public static Result<T> Failure(string propertyName, string message) => 
        new(new[] { new Notification(propertyName, message) });
}