namespace AdapterPattern;

public interface SocketAdapter
{
    public Volt Get3Volt();
    public Volt Get120Volt();
    public Volt Get240Volt();
    
}