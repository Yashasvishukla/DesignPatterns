using ObserverPattern.WeatherStationV2;
using ObserverPattern.WeatherStationV2.Displays;

namespace ObserverPattern.WeatherStationV3;

public class CurrentConditionDisplay: IObserver<WeatherData>, IDisplay
{
    private float _temperature;
    private float _humidity;
    private readonly IDisposable _disposable;

    public CurrentConditionDisplay(WeatherData weatherData)
    {
        _disposable = weatherData.Subscribe(this);
    }
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        Console.WriteLine(error.Message);
    }

    public void OnNext(WeatherData value)
    {
       // Fetch the data that we want
       _temperature = value.GetTemperature();
       _humidity = value.GetHumidity();
       Display();
    }
    public void Display()
    {
        Console.WriteLine($"Current Conditions {_temperature} F Degrees and Humidity {_humidity}");
    }

    public void Unsubscribe()
    {
        _disposable.Dispose();
    }
    
}