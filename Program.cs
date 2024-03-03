namespace observer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
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

