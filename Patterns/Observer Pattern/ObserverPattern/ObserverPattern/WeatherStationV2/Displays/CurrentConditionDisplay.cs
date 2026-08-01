using System;

namespace ObserverPattern.WeatherStationV2.Displays;

public class CurrentConditionDisplay: IObserver, IDisplay
{
    private float _temperature;
    private float _humidity;
    private readonly ISubject _weatherData;

    public CurrentConditionDisplay(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);  // We are registering the CurrentCondition with the WeatherData Subject
    }
    public void Update(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        Display();
    }

    public void Update(IState state)
    {
        // Display(state);
    }

    public void Display()
    {
        Console.WriteLine($"Current Conditions {_temperature} F Degrees and Humidity {_humidity}");
    }
}