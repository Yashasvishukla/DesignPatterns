namespace ObserverPattern.WeatherStationV3;

public class Unsubscribe<T>: IDisposable
{
    private readonly ISet<IObserver<T>> _observers;
    private readonly IObserver<T> _observer;

    public Unsubscribe(ISet<IObserver<T>> observers,
        IObserver<T> observer
        )
    {
        _observers = observers;
        _observer = observer;
    }
    public void Dispose()
    {
        var result = _observers.Remove(_observer);
        if(!result) Console.WriteLine("Unable to remove the registration");
        Console.WriteLine("Disposed the Observer from Observers List");
    }
}