using System;
using System.Collections.Generic;

namespace Cielo.Responses
{
    public class CheckTransactionResponse
    {
        public int ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public List<PaymentResponse> Payments { get; set; }
    }
    public class PaymentResponse
    {
        public Guid PaymentId { get; set; }
        public DateTime ReceveidDate { get; set; }
    }
}
