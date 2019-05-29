using System;

namespace LogicWorkshopOfficialExample
{
    public static class LogicEnvironment
    {
        public static Uri LogicApiUrl = new Uri("https://kmd-logic-api-prod-webapp.azurewebsites.net");
        public static Guid SubscriptionId = Guid.Parse("");
        public static Guid SmsConfigurationId = Guid.Parse("");

        public static string UriAuthorizationServer = "https://login.microsoftonline.com/logicidentityprod.onmicrosoft.com/oauth2/v2.0/token";
        public static string ClientId = "";
        public static string Scope = "https://logicidentityprod.onmicrosoft.com/bb159109-0ccd-4b08-8d0d-80370cedda84/.default";
        public static string ClientSecret = "";

        public static string SerilogAzureEventHubConnectionString = "";

        public static string SerilogAzureEventHubEventSource = "";
    }
}
