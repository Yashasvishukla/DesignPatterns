namespace ObserverPattern.WeatherStationV3;

public class WeatherData: IWeatherObservable<WeatherData>
{
    private readonly ISet<IObserver<WeatherData>> _observers = new HashSet<IObserver<WeatherData>>();

    
    private float Temperature { get; set; }
    private float Humidity { get; set; }
    private float Pressure { get; set; }

    
    public float GetTemperature() => Temperature;
    public float GetPressure() => Pressure;
    public float GetHumidity() => Humidity;
    
    public IDisposable Subscribe(IObserver<WeatherData> observer)
    {
        if (_observers.Add(observer))
        {
            observer.OnNext(this);             // I am transferring the observable object so the observer can pick the information which they want 
            Console.WriteLine("The values pushed during the Registration");
        }
        else
        {
            observer.OnError(new ArgumentException("Observer already registered"));
        }

        return new Unsubscribe<WeatherData>(_observers, observer);
    }


    public void SetMeasurements(float temperature, float pressure, float humidity)
    {
        Temperature = temperature;
        Pressure = pressure;
        Humidity = humidity;
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(this);
        }
    }
    
}