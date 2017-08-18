using System;
using Cielo.Responses.Entities;

namespace Cielo.Responses
{
    public class CheckTransactionResponse
    {
        public string MerchantOrderId { get; set; }
        public CustomerResponse Customer { get; set; }
        public PaymentResponse Payment { get; set; }
    }
}
