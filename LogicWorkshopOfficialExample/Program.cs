using Kmd.Logic.Audit.Client;
using Kmd.Logic.Audit.Client.SerilogAzureEventHubs;
using System;
using System.Threading.Tasks;

namespace LogicWorkshopOfficialExample
{
    class Program
    {

        public static IAudit AuditInstance { get; set; }

        static async Task Main()
        {
            InitAudit();

            await SmsSender.SendAsync(LogicEnvironment.SMSMessageBody, LogicEnvironment.ToPhoneNumber);

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
