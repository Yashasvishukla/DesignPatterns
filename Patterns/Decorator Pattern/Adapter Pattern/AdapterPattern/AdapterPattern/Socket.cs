namespace AdapterPattern;

public class Socket
{
    public Socket()
    {
        
    }
    
    // Indian Socket Volt
    public  Volt GetVolts()
    {
        return new Volt(240);
    }
}