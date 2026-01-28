namespace StoxPlus.Infrastructure.Const
{
    public static class ApiUrlPathConst
    {
        public static class RealTimeApi
        {
            public const string Stock = "/api/v1/Realtime/stock/tradingview/data";
            public const string Index = "/api/v1/Realtime/index/tradingview/data";
            public const string Sector = "/api/v1/Realtime/sector/tradingview/data";
            public const string Derivative = "/api/v1/Realtime/future/tradingview/data";
            public const string CW = "/api/v1/Realtime/coveredwarrant/tradingview/data";

            public const string BUSDDerivative = "/api/v1/Realtime/future/tradingview/busd";
            public const string BUSDCw = "/api/v1/Realtime/coveredwarrant/tradingview/busd";
            public const string BUSDSector = "/api/v1/Realtime/sector/tradingview/busd";
            public const string BUSDIndex = "/api/v1/Realtime/index/tradingview/busd";
            public const string BUSDStock = "/api/v1/Realtime/stock/tradingview/busd";
        }
    }
}