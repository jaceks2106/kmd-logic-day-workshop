using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LogicWorkshopOfficialExample
{
    internal class SmsSender
    {
        internal static async Task SendAsync(string messageBody, string toPhoneNumber)
        {
            // 1. Acquire token
            TokenResponse token = await RequestToken();

            // 2. Prepare request
            SmsRequest request = new SmsRequest(toPhoneNumber, messageBody, LogicEnvironment.SmsConfigurationId);

            // 3. Send request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.access_token);

                var response = await client.PostAsJsonAsync(
                    new Uri(new Uri(LogicEnvironment.LogicApiUrl), $"subscriptions/{LogicEnvironment.SubscriptionId}/sms"),
                    request);

                // 4. Get the response message
                var responseMessage = await response.Content.ReadAsAsync<SmsResponse>();

                // 5. Audit an event
                var userId = "xyz@kmd.dk";
                Console.WriteLine($"SMS message with id {responseMessage.SmsMessageId} for configuration {LogicEnvironment.SmsConfigurationId} has been sent by {userId} to '{toPhoneNumber}");
                Program.AuditInstance
                    .ForContext("user", "swr")
                    .Write(
                        "SMS message with id {SmsMessageId} for configuration {ConfigurationId} has been sent by {UserId} to '{ToPhoneNumber}'",
                        responseMessage.SmsMessageId,
                        LogicEnvironment.SmsConfigurationId,
                        userId,
                        toPhoneNumber);
            }
        }

        private static async Task<TokenResponse> RequestToken()
        {
            HttpResponseMessage responseMessage;

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage tokenRequest = new HttpRequestMessage(HttpMethod.Post, LogicEnvironment.UriAuthorizationServer);
                HttpContent httpContent = new FormUrlEncodedContent(
                    new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("client_id", LogicEnvironment.ClientId),
                        new KeyValuePair<string, string>("scope", LogicEnvironment.Scope),
                        new KeyValuePair<string, string>("client_secret", LogicEnvironment.ClientSecret)
                    });
                tokenRequest.Content = httpContent;
                responseMessage = await client.SendAsync(tokenRequest);
            }

            return await responseMessage.Content.ReadAsAsync<TokenResponse>();
        }
    }
}