using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cielo.Enums;
using Cielo.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cielo.Responses
{
    public class EletronicTransferResponse
    {

        #region private vars

        [JsonExtensionData]
        private IDictionary<string, object> _response;

        #endregion

        #region ctor

        public EletronicTransferResponse()
        {
            _response = new Dictionary<string, object>();
        }

        #endregion

        #region methods

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            JObject payment = (JObject)_response["Payment"];
            MerchantOrderId = _response["MerchantOrderId"]?.ToString();
            Url = payment["Url"]?.ToString();
            PaymentId = Guid.Parse(payment["PaymentId"]?.ToString());
            PaymentType = EnumExtension.ToEnum<PaymentType>(payment["Type"]?.ToString());
            int.TryParse(payment["Amount"]?.ToString(), out int amount);
            Amount = amount;
            Currency = payment["Currency"]?.ToString();
            Country = payment["Country"]?.ToString();
            Provider = EnumExtension.ToEnum<EletronicTransferProvider>(payment["Provider"]?.ToString());
            Status = EnumExtension.ToEnum<Status>(payment["Status"]?.ToString());
        }

        #endregion

        #region properties

        public string MerchantOrderId { get; private set; }
        public string Url { get; private set; }
        public Guid PaymentId { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public int Amount { get; private set; }
        public string Currency { get; private set; }
        public string Country { get; private set; }
        public EletronicTransferProvider Provider { get; private set; }
        public Status Status { get; private set; }

        #endregion
    }
}
