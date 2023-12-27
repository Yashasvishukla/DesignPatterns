using StackExchange.Redis;

namespace Redis_playground.Scripts;

public static class FixedRateLimiter
{
    public static LuaScript RateLimitScript => LuaScript.Prepare(RateLimiter);

    /*
     * we are using redis.call method to call internal methods
     * ____ redis.call('INCR', @key) will increment the counter for the specified key
     * ____ redis.call('EXPIRE', @key, @expiry) will set the expiry of the key with the specified duration
     *
     * We are comparing the count of the key with the max allowed request
     * if the count become greater than the maxRequest then return 0 otherwise return 1
     */
    private const string RateLimiter = @"
        local requests = redis.call('INCR', @key)
        redis.call('EXPIRE', @key, @expiry)
        if requests < tonumber(@maxRequests) then
            return 0
        else
            return 1
        end
    ";
}