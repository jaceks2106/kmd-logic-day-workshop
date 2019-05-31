using System;

namespace LogicWorkshopOfficialExample
{
    public static class LogicEnvironment
    {
        public const string LogicApiUrl = "https://kmd-logic-api-prod-webapp.azurewebsites.net";
        public static Guid SubscriptionId = Guid.Parse(""); // Console -> Subscriptions -> Subscription Id
        public static Guid SmsConfigurationId = Guid.Parse(""); // Console -> SMS -> Providers -> Configuration Id

        public const string UriAuthorizationServer = "https://login.microsoftonline.com/logicidentityprod.onmicrosoft.com/oauth2/v2.0/token";
        public const string ClientId = ""; // Console -> Subscriptions -> Client Credentials -> client_id
        public const string Scope = ""; // Console -> Subscriptions -> Client Credentials -> scope
        public const string ClientSecret = ""; // Console -> Subscriptions -> Client Credentials -> client_secret

        public const string SerilogAzureEventHubConnectionString = ""; // Console -> Audit -> Instances -> Primary
        public const string SerilogAzureEventHubEventSource = ""; // Your custom name to identify, who sent the event. It can be changed anytime.

        public const string ToPhoneNumber = ""; // Phone number of example SMS message receiver
        public const string SMSMessageBody = "Hello! You have just received message, that was sent via Logic API!";
    }
}
