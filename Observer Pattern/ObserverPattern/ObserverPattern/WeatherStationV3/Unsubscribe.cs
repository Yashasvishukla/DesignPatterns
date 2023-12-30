namespace ObserverPattern.WeatherStationV3;

public class Unsubscribe: IDisposable
{
    private readonly ISet<IObserver<WeatherData>> _observers;
    private readonly IObserver<WeatherData> _observer;

    public Unsubscribe(ISet<IObserver<WeatherData>> observers,
        IObserver<WeatherData> observer
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