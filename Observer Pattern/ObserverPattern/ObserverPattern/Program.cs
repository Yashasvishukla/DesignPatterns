// See https://aka.ms/new-console-template for more information


/*
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
*/

using ObserverPattern.WeatherStationV3;


WeatherData observable = new WeatherData();

CurrentConditionDisplay currentConditionDisplay = new CurrentConditionDisplay(observable);   // This will automatically take care of the subscription
ForecastDisplay forecastDisplay = new ForecastDisplay(observable);
observable.SetMeasurements(20,50,85);             // Whenever the measurement changes it will notify the observers
currentConditionDisplay.Unsubscribe();
observable.SetMeasurements(40,5,8);                          


/*
    In case if we have to add new property to weather data class
    then we just need to expose the new getter method and the observer can easily make use of it
    So They are loosely coupled with each other
*/