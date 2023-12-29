using System;

namespace ObserverPattern.WeatherStationV2.Displays;

public class HeatIndexDisplay: IObserver, IDisplay
{
    private readonly ISubject _weatherData;
    private float _humidity;
    private float _temperature;

    public HeatIndexDisplay(ISubject weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        Display();
    }

    private double HeatIndex(float t, float rh)
    {
        var heatIndex = 16.923 + 1.85212 * 10 - 1 * t + 5.37941 * rh - 1.00254 * 10 - 1 * t
            * rh + 9.41695 * 10 - 3 * Math.Pow(t, 2) + 7.28898 * 10 - 3 * Math.Pow(rh, 2) + 3.45372 * 10 - 4
            * Math.Pow(t, 2) * rh - 8.14971 * 10 - 4 * t * Math.Pow(rh, 2) + 1.02102 * 10 -
            5 * Math.Pow(t, 2) * Math.Pow(rh, 2) -
            3.8646 * 10 - 5 * Math.Pow(t, 3) + 2.91583 * 10 - 5 * Math.Pow(rh, 3) + 1.42721 * 10 -
            6 * Math.Pow(t, 3) * rh
            + 1.97483 * 10 - 7 * t * Math.Pow(rh, 3) - 2.18429 * 10 - 8 * Math.Pow(t, 3) * Math.Pow(rh, 2) + 8.43296 *
            10 - 10 * Math.Pow(t, 2) * Math.Pow(rh, 3) - 4.81975 * 10 - 11 * Math.Pow(t, 3) * Math.Pow(rh, 3);

        return heatIndex;
    }
    public void Update(IState state)
    {
        throw new NotImplementedException();
    }

    public void Display()
    {
        Console.WriteLine($"Heat Index is ---------> {HeatIndex(_temperature, _humidity)}");
    }
}