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
            // 1. Uzyskaj token
            TokenResponse token = await RequestToken();

            // 2. Utworz request
            SmsRequest request = new SmsRequest(toPhoneNumber, messageBody, LogicEnvironment.SmsConfigurationId);

            // 3. Wyslij request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.access_token);

                // 4. Odbierz response
                var response = await client.PostAsJsonAsync(
                    new Uri(LogicEnvironment.LogicApiUrl, $"subscriptions/{LogicEnvironment.SubscriptionId}/sms"),
                    request);

                // 5. Dodaj do audytu
                Program.AuditInstance
                    .ForContext("user", "swr")
                    .Write(
                        "Wiadomość dla konfiguracji {ConfigurationId} została wysłana przez użytkownika {UserId}",
                        LogicEnvironment.SmsConfigurationId,
                        "swr@kmd.dk");
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