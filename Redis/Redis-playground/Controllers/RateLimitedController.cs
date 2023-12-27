
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Redis_playground.Scripts;
using StackExchange.Redis;

namespace Redis_playground.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RateLimitedController: ControllerBase
{
    private readonly IDatabase _redis;

    public RateLimitedController(IConnectionMultiplexer connectionMultiplexer)
    {
        _redis = connectionMultiplexer.GetDatabase();
    }

    [HttpPost]
    public async Task<IActionResult> SimpleAuth([FromHeader] string authorizationHeader)
    {
        
        var encoded = string.Empty;
        if(!string.IsNullOrEmpty(authorizationHeader))
            encoded = authorizationHeader;
        if (string.IsNullOrEmpty(encoded)) return new UnauthorizedResult();
        var apiKey = Encoding.UTF8.GetString(Convert.FromBase64String(encoded)).Split(":")[0];

        // Rate Limiter Logic

        var script = FixedRateLimiter.RateLimitScript;
        
        /*
         * The way we have stored the key is very important
         * 12:20 so from 12:20 -> 12:20:59 we the user hit the endpoint more than 5 times then
         * it will start sending the response as 429
         * The moment we reach to 12:21 it will begin to serve the response again
         */
        var key = $"{Request.Path.Value}:{apiKey}:{DateTime.UtcNow:hh:mm:}";
        
        
        var result = await _redis.ScriptEvaluateAsync(script, new
        {
            key = new RedisKey(key),
            expiry = 60,
            maxRequests = 5
        });

        
        return (int)result == 1 ? new StatusCodeResult(429) : new OkResult();
    }
}