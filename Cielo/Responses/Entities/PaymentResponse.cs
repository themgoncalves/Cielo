using System;
using System.Collections.Generic;
using Cielo.Enums;

namespace Cielo.Responses.Entities
{
    public class PaymentResponse
    {
        public int ServiceTaxAmount { get; set; }
        public int Installments { get; set; }
        public string Interest { get; set; }
        public bool Capture { get; set; }
        public bool Authenticate { get; set; }
        public CreditCardResponse CreditCard { get; set; }
        public DebitCardResponse DebitCard { get; set; }
        public string ProofOfSale { get; set; }
        public string Tid { get; set; }
        public string AuthorizationCode { get; set; }
        public Guid PaymentId { get; set; }
        public PaymentType Type { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public List<object> ExtraDataCollection { get; set; }
        public Status Status { get; set; }
        public List<LinkResponse> Links { get; set; }
    }
}
