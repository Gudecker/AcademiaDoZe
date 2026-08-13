//Gustavo Decker Couto
namespace AcademiaDoZe.Domain.Common;

public class Notification
{
    public string PropertyName { get; }
    public string Message { get; }

    public Notification(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }
}