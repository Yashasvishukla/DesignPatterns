// See https://aka.ms/new-console-template for more information


using System;
using ObserverPattern.WeatherStationV2;
using ObserverPattern.WeatherStationV2.Displays;

WeatherData weatherData = new WeatherData();

// Register the Observers
IObserver currentCondition = new CurrentConditionDisplay(weatherData);
IObserver forecastCondition = new ForecastDisplay(weatherData);
IObserver statisticsCondition = new StatisticsDisplay(weatherData);
IObserver heatIndexDisplay = new HeatIndexDisplay(weatherData);


weatherData.SetMeasurement(10, 20, 30);
Console.WriteLine();
weatherData.SetMeasurement(100, 20, 30);
Console.WriteLine();
weatherData.SetMeasurement(10, 20, 300);
Console.WriteLine();
weatherData.SetMeasurement(80, 80, 80);







weatherData.MeasurementChanged();


weatherData.MeasurementChanged();