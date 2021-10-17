using System;
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
            Console.WriteLine(messageReceiver.PrefetchCount);
            await Task.Delay(5000);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
