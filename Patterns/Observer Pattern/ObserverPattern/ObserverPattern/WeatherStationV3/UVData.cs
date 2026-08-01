namespace ObserverPattern.WeatherStationV3;

public class UvData: IWeatherObservable<UvData>
{
    private readonly ISet<IObserver<UvData>> _observers = new HashSet<IObserver<UvData>>();
    
    
    public IDisposable Subscribe(IObserver<UvData> observer)
    {
        if (_observers.Add(observer))
        {
            observer.OnNext(this);
        }

        return new Unsubscribe<UvData>(_observers, observer);
    }
    

    public float GetTemperature()
    {
        throw new NotImplementedException();
    }

    public float GetHumidity()
    {
        throw new NotImplementedException();
    }

    public float GetPressure()
    {
        throw new NotImplementedException();
    }
}