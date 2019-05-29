using System;

namespace LogicWorkshopOfficialExample
{
    public static class LogicEnvironment
    {
        public static Uri LogicApiUrl = new Uri("https://kmd-logic-api-prod-webapp.azurewebsites.net");
        public static Guid SubscriptionId = Guid.Parse(""); // Console -> Subscriptions -> Subscription Id
        public static Guid SmsConfigurationId = Guid.Parse(""); // Console -> SMS -> Providers -> Configuration Id

        public static string UriAuthorizationServer = "https://login.microsoftonline.com/logicidentityprod.onmicrosoft.com/oauth2/v2.0/token";
        public static string ClientId = ""; // Console -> Subscriptions -> Client Credentials -> client_id
        public static string Scope = ""; // Console -> Subscriptions -> Client Credentials -> scope
        public static string ClientSecret = ""; // Console -> Subscriptions -> Client Credentials -> client_secret

        public static string SerilogAzureEventHubConnectionString = ""; // Console -> Audit -> Instances -> Primary

        public static string SerilogAzureEventHubEventSource = ""; // Your custom name to identify, who sent the event. It can be changed anytime.
    }
}
