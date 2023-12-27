using System.Collections;

namespace Redis_playground;

public class ForecastResult
{
    public ForecastResult(long elapsedTime, string forecasts)
    {
        ElapsedTime = elapsedTime;
        Forecasts = forecasts;
    }

    public long ElapsedTime { get; }
    public string Forecasts { get; }
    
}