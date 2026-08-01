using ObserverPattern.WeatherStationV2.Displays;

namespace ObserverPattern.WeatherStationV3;

public class ForecastDisplay: IObserver<WeatherData>, IDisplay
{
    private float _temperature;
    private float _humidity;
    private float _pressure;
    private readonly IDisposable _disposable;

    public ForecastDisplay(WeatherData weatherData)
    {
        _disposable = weatherData.Subscribe(this);
    }
    
    public void Display()
    {
        Console.WriteLine($"Temperature ----> {_temperature}, Humidity -----> {_humidity} , Pressure ------> {_pressure}");
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(WeatherData value)
    {
        _temperature = value.GetTemperature();
        _humidity = value.GetHumidity();
        _pressure = value.GetPressure();
        Display();
    }

    public void UnSubscribe()
    {
        _disposable.Dispose();
    }
}