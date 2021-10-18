using System;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus.Core;
using System.Threading.Tasks;

namespace Toy_ServiceBusSession
{
    public static class ServiceBusPreFetch
    {
        [FunctionName("ServiceBusPreFetch")]
        public async static Task Run(
            [ServiceBusTrigger("toy-prefetch", Connection = "ServiceBusConnection")]string myQueueItem,
            MessageReceiver messageReceiver,
            ILogger log)
        {
            var messages = await messageReceiver.ReceiveAsync(100);
            foreach(var message in messages)
            {
                var txt = Encoding.GetEncoding("utf-8").GetString(message.Body);
                Console.WriteLine(txt);
            }
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
