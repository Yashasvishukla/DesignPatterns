namespace ObserverPattern.WeatherStationV1;

/*
 * 
 */
public class WeatherDataV1
{


 public float GetTemperature()
 {
  return 100.00f;
  // This is going to return the updated  temperature
 }

 public float GetHumidity()
 {
  return 50.00000f;
  // return the latest/ updated humidity value
 }

 public float GetPressure()
 {
  return .2525f;
  // return the updated pressure value
 }
 
 public void MeasurementChanged()
 {
  // Fetch the latest values and update the displays
  float temperature = GetTemperature();
  float humidity = GetHumidity();
  float pressure = GetPressure();
  
  /*
   *  currentConditionDisplay.update(temperature, humidity, pressure);
   *  statisticsDisplay.update(temperature, humidity, pressure);             ---------------> At least we seem  to be using common interface to talk to display elements
   *  forecastDisplay.update(temperature, humidity, pressure);                                they all have update() method that takes temp, humidity, pressure.
   */
  
  
  /*
   *                                |
   *                                |
   *                                |
   *                                |
   *                                |
   *                                |
   *                                |
   *                     By coding to concrete implementations we have no way
   *                    to add or remove other display elements without making changes to the program.
   */
 }
}







/*
 * Lets suppose we have three different displays as of now
 * CurrentConditionDisplay
 * StatisticsDisplay
 * ForecastDisplay
*/