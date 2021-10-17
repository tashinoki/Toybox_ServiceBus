using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Toy_ServiceBusSession
{
    public static class Subscriber
    {
        [FunctionName("Subscriber")]
        public async static Task Run(
            [ServiceBusTrigger("sample", Connection = "ServiceBusConnection", IsSessionsEnabled = true)]string myQueueItem,
            ExecutionContext context,
            ILogger log)
        {
            Console.WriteLine(context.InvocationId);
            await Task.Delay(10000);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
