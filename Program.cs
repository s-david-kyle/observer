namespace observer;

class Program
{
    static void Main(string[] args)
    {
        var observable = new EventBasedObservable();
        var observer = new EventBasedObserver(observable);

        observable.FireEvent("Hello, World!");
    }
}

public class MessageEventArgs : EventArgs
{
    public string Message { get; set; }
    public MessageEventArgs(string message)
    {
        Message = message;
    }
}

public class EventBasedObservable
{
    public event EventHandler<MessageEventArgs>? Event;
    public void FireEvent(string message)
    {
        Event?.Invoke(this, new(message));
    }
}

public class EventBasedObserver
{
    public EventBasedObserver(EventBasedObservable observable)
    {
        observable.Event += OnEvent;
    }
    public void OnEvent(object? sender, MessageEventArgs e)
    {
        Console.WriteLine($"Event fired: {e.Message}");
    }
}
