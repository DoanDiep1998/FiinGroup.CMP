namespace StoxPlus.Infrastructure.Const
{
    public class GlobalConst
    {
        public static readonly string[] AllowedLanguages = { "vi", "en", "ja" };
        public static readonly string FiinTradeServiceType = "FiinGroup.FiinTrade";
        public static readonly string FiinPremium = "FiinTrade.Premium";
        public static readonly string FiinTrial = "FiinTrade.Trial";

        public static readonly int InMemLatencyToRedisInMinutes = 5;

        public static readonly int StatisticStorePreloadEarlyInMinutes = 30;
    }

    public class CommonConst
    {
        public static readonly string DateFormat = "yyyy-MM-dd'T'00:00:00";
    }

    public class ClientIDConst
    {
        public static readonly string FiinTradeMobile = "FiinGroup.FiinTrade.MobileApp";
        public static readonly string FiinTradeSPA = "StoxPlus.FiinTrade.SPA";
    }

    public static class MarketStatusConst
    {
        public const string ATC = "ATC";
        public const string ATC_CLOSED = "ATC_CLOSE";
    }

    public static class ComTypeCodeConst
    {
        public const string NH = "NH";
        public const string CT = "CT";
        public const string CK = "CK";
    }
}
