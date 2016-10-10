using System;
using RedisDemo.Services;

namespace DemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MessageService();

            for (int i = 0; i < 10; i++)
            {
                var message = $"Created message {i + 1}";
                service.AddMessage(message);

                Console.WriteLine(message);
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
