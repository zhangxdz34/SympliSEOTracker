namespace SympliSEOTracker.Repository
{
    using System;
    using System.Runtime.Caching;

    public abstract class GenericCachedDataProvider<T> where T : class
    {
        public static ObjectCache _cache = new MemoryCache($"{typeof(T).Name}_cache");

        protected GenericCachedDataProvider()
        {
        }

        public void SaveToCache(string cacheKey, T objectToCache, DateTimeOffset? cacheAbsoluteExpiration = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = cacheAbsoluteExpiration ?? DateTime.Now.AddMinutes(5)
            };

            _cache.Add(cacheKey, objectToCache, policy);
        }

        public T GetFromCache(string cacheKey)
        {
            return (T)_cache.Get(cacheKey);
        }

        public void ClearCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        /// <summary>
        /// generate cache key by combining a provided key and tenant id
        /// provided key can by id/uniqeid of the object
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GenerateCacheKey(string key)
        {
            return $"Cache_{key}";
        }

    }
}
