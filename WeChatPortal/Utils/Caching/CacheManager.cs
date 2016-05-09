using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace WeChatPortal.Utils.Caching
{

    public class CacheManager : ICacheManager
	{
	    readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache;

        public void Set(string key, object data)
        {
            _cache.Insert(key, data);
        }
        public void Set(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cache.Insert(key, data, null,absoluteExpiration, slidingExpiration);
        }

		public object Get(string Key)
		{
			return _cache[Key];
		}

        public T Get<T>(string key)
        {
            return (T)_cache[key];
        }

        public bool IsSet(string key)
        {
            return _cache[key] != null;
        }

        public void Remove(string Key)
		{
			if (_cache[Key] != null) {
				_cache.Remove(Key);
			}
		}

		public void RemoveByPattern(string pattern)
		{
			IDictionaryEnumerator enumerator = _cache.GetEnumerator();
			Regex rgx = new Regex(pattern, (RegexOptions.Singleline | (RegexOptions.Compiled | RegexOptions.IgnoreCase)));
			while (enumerator.MoveNext()) {
				if (rgx.IsMatch(enumerator.Key.ToString())) {
					_cache.Remove(enumerator.Key.ToString());
				}
			}
		}

        public void Clear()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                _cache.Remove(enumerator.Key.ToString());
            }
        }

	}

}