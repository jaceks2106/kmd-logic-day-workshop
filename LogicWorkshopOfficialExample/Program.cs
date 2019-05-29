using Kmd.Logic.Audit.Client;
using Kmd.Logic.Audit.Client.SerilogAzureEventHubs;
using System;
using System.Threading.Tasks;

namespace LogicWorkshopOfficialExample
{
    class Program
    {
        // Example client, that sends SMS and audits events through Logic Gateway. Whole application was written during the Logic Day Workshop.

        public static IAudit AuditInstance { get; set; }

        static async Task Main()
        {
            InitAudit();

            string messageBody = "Hello World!";
            string toPhoneNumber = "";

            await SmsSender.SendAsync(messageBody, toPhoneNumber);

            Console.ReadKey();
        }

        private static void InitAudit()
        {
            AuditInstance = new SerilogAzureEventHubsAuditClient(
                new SerilogAzureEventHubsAuditClientConfiguration
                {
                    ConnectionString = LogicEnvironment.SerilogAzureEventHubConnectionString,
                    EventSource = LogicEnvironment.SerilogAzureEventHubEventSource,
                    EnrichFromLogContext = true,
                }
            );
        }
    }
}
