using System;
using System.Collections.Generic;
using Cielo.Responses.Entities;

namespace Cielo.Responses
{
    public class CheckTransactionResponse
    {
        public string ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public List<PaymentResponse> Payments { get; set; }
        public string MyProperty { get; set; }
        public string MerchantOrderId { get; set; }
        public CustomerResponse Customer { get; set; }
        public PaymentResponse Payment { get; set; }
    }
}
