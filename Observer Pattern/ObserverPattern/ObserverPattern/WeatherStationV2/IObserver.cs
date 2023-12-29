namespace ObserverPattern.WeatherStationV2;

public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);  // These are the state vales the observer get from the subject when a weather measurement changes
}

/*
 * void Update(float temperature, float humidity, float pressure);
 * These are the state vales the observer get from the subject when a weather measurement changes
 * The measurement are directly passed to the observers that is the most straightforward method to update the state.  <---------- IMP
 *
 * Is this an area of the application that might change in the future                                                 <---------- IMP Questions
 * Would the change be well encapsulated or would it require change in many parts of the code
 *
 * 
*/