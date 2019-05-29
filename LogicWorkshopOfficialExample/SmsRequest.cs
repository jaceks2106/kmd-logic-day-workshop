using System;

namespace LogicWorkshopOfficialExample
{
    internal class SmsRequest
    {
        public string ToPhoneNumber { get; set; }
        public string Body { get; set; }
        public string CallbackUrl { get; set; }
        public Guid ProviderConfigurationId { get; set; }

        public SmsRequest(string toPhoneNumber, string body, Guid providerConfigurationId, string callbackUrl = null)
        {
            ToPhoneNumber = toPhoneNumber;
            Body = body;
            CallbackUrl = callbackUrl;
            ProviderConfigurationId = providerConfigurationId;
        }
    }
}