using System;

namespace WeChatPortal.Utils.Caching
{

	public interface ICacheManager
	{

        T Get<T>(string key);
        object Get(string key);

        void Set(string key, object data);
        void Set(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        bool IsSet(string key);        
        void Remove(string key);
        void RemoveByPattern(string pattern);        
        void Clear();

	}

}