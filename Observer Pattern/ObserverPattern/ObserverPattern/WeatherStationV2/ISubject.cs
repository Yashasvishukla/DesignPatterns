﻿namespace ObserverPattern.WeatherStationV2;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObserver();
}