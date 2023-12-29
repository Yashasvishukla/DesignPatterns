using System;

namespace ObserverPattern.WeatherStationV2.Displays;

public class ForecastDisplay: IObserver, IDisplay
{
    private float _temperature;
    private float _humidity;
    private float _pressure;
    private readonly ISubject _weatherData;

    public ForecastDisplay(ISubject weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        Display();
    }
    

    public void Display()
    {
        Console.WriteLine($"Temperature ----> {_temperature}, Humidity -----> {_humidity} , Pressure ------> {_pressure}");
    }
}