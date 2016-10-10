using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisDemo.Services
{
    public class MessageService
    {
        public void AddMessage(string message)
        {
            var msg = new Message
            {
                Value = message,
                CreatedDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var client = CacheService.CacheClient;
            var key = GetKey(msg.Id);
            client.Add(key, msg, DateTimeOffset.Now.AddDays(14));
        }

        public void RemoveMessage(Guid messageId)
        {
            var client = CacheService.CacheClient;
            var key = GetKey(messageId);
            client.Remove(key);
        }

        public IList<Message> GetAllMessages()
        {
            var client = CacheService.CacheClient;

            var founKeys = client.SearchKeys("__key__*");
            var enumerable = founKeys as string[] ?? founKeys.ToArray();
            if (founKeys == null || !enumerable.Any())
            {
                return new List<Message>();
            }

            var result = client.GetAll<Message>(enumerable);
            return result.Values.ToList();
        }

        public void DeleteAllMessages()
        {
            var client = CacheService.CacheClient;
            var founKeys = client.SearchKeys("__key__*");
            var enumerable = founKeys as string[] ?? founKeys.ToArray();
            if (founKeys == null || !enumerable.Any())
            {
                return;
            }

            client.RemoveAll(enumerable);
        }

        protected virtual string GetKey(Guid messageId)
        {
            return $"__key__{messageId}";
        }
    }
}
