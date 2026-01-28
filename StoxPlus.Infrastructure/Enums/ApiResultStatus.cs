namespace StoxPlus.Infrastructure.Enums
{
    public enum ApiResultStatus
    {
        Success = 1,
        Failed ,
        Timeout,
        Queued,
        Apart,
        MarketClosed,
        MarketPreOpen,
        ApiAccessFailed,
        TickerLimitFailed,
        TimeFrameLimitFailed,
        MaxRequestLimitFailed,
        RatelimitFailed,
    }
}
