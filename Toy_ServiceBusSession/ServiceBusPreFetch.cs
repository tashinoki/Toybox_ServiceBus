using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Toy_ServiceBusSession
{
    public static class ServiceBusPreFetch
    {
        [FunctionName("ServiceBusPreFetch")]
        public static void Run(
            [ServiceBusTrigger("toy-prefetch", Connection = "ServiceBusConnection")]string myQueueItem,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
