using FiinGroup.Packages.CacheManager;
using FiinGroup.Packages.Mediator;

namespace StoxPlus.Infrastructure.Behaviors
{
    public class MediatorCacheHandler : ICacheHandler
    {
        private readonly ICache _cache;

        public MediatorCacheHandler(ICache cache)
        {
            _cache = cache;
        }

        public TRespone Get<TRespone>(string key)
        {
            return _cache.Get<TRespone>(key);
        }

        public void Set<TRespone>(string key, TRespone respone, CacheOption cacheOption)
        {
            if (cacheOption?.Expire != null)
            {
                _cache.Add(key, respone, cacheOption.Absolute == true ? ExpirationMode.Absolute : ExpirationMode.Sliding, cacheOption.Expire);
            }
            else
            {
                _cache.Add(key, respone);
            }
        }
    }
}
