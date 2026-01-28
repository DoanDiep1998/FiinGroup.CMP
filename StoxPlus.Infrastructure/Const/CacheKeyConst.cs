namespace StoxPlus.Infrastructure.Const
{
    public static class CacheKeyConst
    {
        public static readonly string CacheKeyPrefix = "FiinQuantCache";
        
        //Limit
        public static readonly string RateLimit = "RateLimit";
        public static readonly string AccessLimitConfig = "AccessLimitConfig";
        public static readonly string RealtimeConnection = "RealtimeConnection";
        public static readonly string RealtimeTicker = "RealtimeTicker";
        public static readonly string TickerUsage = "TickerUsage";
        public static readonly string RequestCount = "RequestUsage";

        //Logging
        public static readonly string LogRequestQueue = "LogRequestQueue";
        public static readonly string LogCCU = "LogCCU";

        public static readonly string AllOrganizations = "AllOrganizations";
        public static readonly string AllOrganizationsDict = "AllOrganizationsDict";
        public static readonly string AllSectors = "AllSectors";
        public static readonly string AllComGroups = "AllComGroups";
        public static readonly string AllDerivatives = "AllDerivatives";
        public static readonly string WorkingFromDateByTimeRange = "WorkingFromDateByTimeRange";
        public static readonly string TickersByComGroup = "TickersByComGroup";
        public static readonly string OrganCodesByComGroup = "OrganCodesByComGroup";
        public static readonly string OrganCodesByComGroupIcb = "OrganCodesByComGroupIcb";
        public static readonly string OrganCodeTickersByComGroup = "OrganCodeTickersByComGroup";
        public static readonly string ComGroupCodesByOrganCodeDict = "ComGroupCodesByOrganCodeDict";
        public static readonly string OutstandingShareDict = "OutstandingShareDict";

        public static readonly string AllCoveredWarrants = "AllCoveredWarrants";

        public static readonly string AllChartIndicators = "AllChartIndicators";

        public static readonly string ChartDataFormat = "ChartData{0}{1}";
        public static readonly string IndicesChartDataFormat = "IndicesChartData{0}{1}";
        public static readonly string SectorChartDataFormat = "SectorChartData{0}{1}";
        public static readonly string DerivativesChartDataFormat = "DerivativesChartData{0}{1}";
        public static readonly string EconomyChartDataFormat = "EconomyChartDataFormat{0}{1}";

        #region Indicator Ta chart

        public static readonly string IndicatorsChartDataFormat = "IndicatorsChartDataFormat{0}{1}";
        public static readonly string IndicatorsIndexChartDataFormat = "IndicatorsIndexChartDataFormat{0}{1}";
        public static readonly string IndicatorsCWChartDataFormat = "IndicatorsCWChartDataFormat{0}{1}";
        public static readonly string IndicatorsSectorChartDataFormat = "IndicatorsSectorChartDataFormat{0}{1}";
        public static readonly string IndicatorsDerivativeChartDataFormat = "IndicatorsDerivativeChartDataFormat{0}{1}";

        #endregion Indicator Ta chart

        public static readonly string ChartEventFormat = "ChartEvent{0}";
        public static readonly string ComGroupBuSdChartFormat = "ComGroupBuSdChart{0}{1}";
        public static readonly string WorldIndexChartFormat = "WorldIndexChart{0}{1}";
        public static readonly string CommodityChartFormat = "CommodityChart{0}{1}";

        public static readonly string StockForeignFormat = "StockSetForeign{0}{1}";
        public static readonly string CWForeignFormat = "CWSetForeign{0}{1}";
        public static readonly string IndexForeignFormat = "IndexSetForeign{0}{1}";
        public static readonly string DerivativeForeignFormat = "DerivativeSetForeign{0}{1}";

        public static readonly string OrganCodesWatchListCacheKey = "OrganCodesWatchList{0}";
        public static readonly string TickersByWatchListCacheKey = "TickersByWatchList{0}{1}";

        public static readonly string StockTopVolumeCacheKeyFormat = "StockTopVolume{0}";

        public static readonly string AuditIpCacheKey = "AUDITIp";
        public static readonly string AuditUrlCacheKey = "AUDITUrl";
        public static readonly string AuditServiceCacheKey = "AUDITService";

        public static readonly string AuditOrganCodeCacheKey = "AuditOrganCode";
        public static readonly string AuditOrganCodeTechnicalIndicatorCacheKey = "AuditOrganCodeTechnicalIndicator";

        public static readonly string ComGroupBuSdHashKeyFormat = "ComGroupBuSdAccumulation{0}{1}";
        public static readonly string ComGroupIndexBuSdHashKeyFormat = "ComGroupIndexBuSdAccumulation{0}";

        public static readonly string TickerBuSdHashKeyFormat = "TickerBuSdAccumulation{0}{1}";
        public static readonly string TickerPriceBuSdHashKeyFormat = "TickerPriceBuSdAccumulation{0}";

        public static readonly string AllMobCalendarItems = "AllMobCalendarItems";

        public static readonly string NotificationSubscriptionByUser = "NotificationSubscriptionByUser{0}";

        public static readonly string NotificationCategoryHierachy = "NotificationCategoryHierachy";

        public static readonly string AllNotificationCategories = "AllNotificationCategories";

        public static readonly string AllIcbCodeComGroupCode = "AllIcbCodeComGroupCode";

        public static readonly string SecurityCode = "SecurityCode";
    }
}