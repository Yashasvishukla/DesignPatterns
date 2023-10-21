namespace AdapterPattern;

public class SocketObjectAdapterImplementation: SocketAdapter
{
    /*
     * This approach focus on the composition of the adaptee class and implementing the SocketAdapter class
     * 
     */

    private Socket _socket = new();
    

    public Volt Get3Volt()
    {
        return ConvertVolt(_socket.GetVolts(), 30);
    }

    public Volt Get120Volt()
    {
        return ConvertVolt(_socket.GetVolts(), 10);
    }

    public Volt Get240Volt()
    {
        return _socket.GetVolts();
    }
    
    // ConvertVolt should be responsible to convert the volt values
    private Volt ConvertVolt(Volt v, int i)
    {
        return new Volt(v.GetVolts() / i);
    }
}