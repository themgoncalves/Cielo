using System;
using Cielo.Request.Entites;
using Cielo.Responses;

namespace Cielo
{
    public interface ICieloService
    {
        NewTransactionResponse CreateTransaction(TransactionRequest request);
        TransactionResponse CancelTransaction(Guid? paymentId = null, string merchantOrderId = null);
        TransactionResponse CaptureTransaction(Guid paymentId, decimal amount = 0);
        CheckTransactionResponse CheckTransaction(Guid? paymentId = null, string merchantOrderId = null);
        CardResponse SaveCard(CreditCardRequest request);
    }
}
