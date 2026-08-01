namespace AdapterPattern;

public class SocketClassAdapterImplementation: Socket, SocketAdapter
{
    /*
     * In Class adapter pattern we extend both the Target and adaptee
     */
    public Volt Get3Volt()
    {
        return ConvertVolt(GetVolts(), 30);
    }

    public Volt Get120Volt()
    {
        return ConvertVolt(GetVolts(), 10);
    }

    public Volt Get240Volt()
    {
        return GetVolts();
    }
    
    
    // ConvertVolt should be responsible to convert the volt values
    private Volt ConvertVolt(Volt v, int i)
    {
        return new Volt(v.GetVolts() / i);
    }
}