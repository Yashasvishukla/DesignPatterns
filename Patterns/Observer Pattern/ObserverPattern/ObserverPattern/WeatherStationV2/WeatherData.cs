using System;
using System.Collections.Generic;

namespace ObserverPattern.WeatherStationV2;

public class WeatherData: ISubject
{
    public List<IObserver> Observers { get; } = new();
    public float Temperature { get; set; }
    public float Pressure { get; set; }
    public float Humidity { get; set; }
    
    
    public void RegisterObserver(IObserver observer)
    {
        if (observer == null)
            throw new ArgumentException("Observer is null. Please provide a valid observer", nameof(observer));

        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observer == null)
            throw new ArgumentException("Observer is null. Please provide a valid observer", nameof(observer));
        var index = Observers.IndexOf(observer);
        if(index >= 0) 
            Observers.RemoveAt(index);
    }

    public void NotifyObserver()
    {
        // We will iterate over all the observers and call the update method
        // This will notify all the observers

        using var iterator = Observers.GetEnumerator();
        while (iterator.MoveNext())
        {
            var observer = iterator.Current;
            observer.Update(Temperature, Humidity, Pressure);
        }
    }


    public void MeasurementChanged()
    {
        // whenever there is a change in the measurement I will invoke the NotifyObserver method
        NotifyObserver();
    }

    public void SetMeasurement(float temperature, float humidity, float pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
        MeasurementChanged();
    }
}