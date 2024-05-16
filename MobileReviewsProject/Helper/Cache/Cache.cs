using Microsoft.Extensions.Caching.Memory;
namespace MobileReviewsProject.Helper.Cache
{
    public class Cache
    {
        private readonly IMemoryCache _cache;
        public Cache(IMemoryCache cache)
        {
            this._cache = cache;
        }
        public string[] GetNames()
        {
            string[] names;
            

            if (!_cache.TryGetValue("names", out names))
            {

                names = new string[] { "Alice", "Bob", "Charlie" };

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                _cache.Set("names", names, cacheEntryOptions);
            }

            return names;
        }
    }


}
