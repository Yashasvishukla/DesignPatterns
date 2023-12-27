using MongoDB.Driver;

namespace url_shorterner.Context;


/*
 * Singleton Class for the MongoClient object
 */
public class MongoClientContext
{
    /*
     * Two ways to implement the singleton class
     * 1. Using the lock approach
     * 2. Using the inbuilt lazy class that allows the constructor to be called only onces
     */
    
    
    // Going with the first approach

    private static MongoClient? _client;
    private static readonly object Padlock = new();
    private MongoClientContext() {}
    public static string? ConnectionString { get; set; }


    public static MongoClient Instance
    {
        get
        {
            if (_client != null) return _client;
            lock (Padlock)
            {
                _client ??= new MongoClient(new MongoUrl(ConnectionString));
            }
            return _client;
        }
    }
}