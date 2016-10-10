using System;

namespace RedisDemo.Services
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Value { get; set; }
    }
}