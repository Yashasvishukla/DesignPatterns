namespace ObserverPattern.WeatherStationV3;

public interface IWeatherObservable<out T>: IObservable<T>
    where T: class
{
    float GetTemperature();
    float GetHumidity();
    float GetPressure();
}