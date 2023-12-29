using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern.WeatherStationV2.Displays;

public class StatisticsDisplay: IObserver, IDisplay
{
    private readonly IList<float> _temperatures = new List<float>();
    private readonly ISubject _weatherData;

    public StatisticsDisplay(ISubject weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }


    public void Update(float temperature, float humidity, float pressure)
    {
        _temperatures.Add(temperature);
        Display();
    }
    

    public void Display()
    {
        var minTemp = _temperatures.Min();
        var maxTemp = _temperatures.Max();
        var avgTemp = _temperatures.Average();
        Console.WriteLine($"Today Statistics are Min Temperature {minTemp} \n Max Temperature {maxTemp} \n AverageTemperature {avgTemp}");
    }
}