namespace AdapterPattern;

public class Volt
{
    private int _volts;
    
    public Volt(int volts)
    {
        _volts = volts;
    }

    public int GetVolts()
    {
        return _volts;
    }

    public void SetVolts(int volts)
    {
        _volts = volts;
    }
    
}