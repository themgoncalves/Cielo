using Cielo.Requests.Entites.Common;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites
{
    public class TransactionRequest
    {
        #region private vars

        private readonly Customer _customer;
        private readonly Payment _payment;

        #endregion

        #region ctor

        /// <summary>
        /// Transaction Information
        /// </summary>
        /// <param name="merchantOrderId">Order Identification</param>
        /// <param name="customer">Customer Information</param>
        /// <param name="payment">Payment Information</param>
        [JsonConstructor]
        public TransactionRequest(string merchantOrderId, Customer customer, Payment payment)
        {
            MerchantOrderId = merchantOrderId;
            _customer = customer;
            _payment = payment;
        }

        #endregion

        #region properties

        public string MerchantOrderId { get; private set; }
        public Customer Customer
        {
            get { return _customer; }
        }
        public Payment Payment
        {
            get { return _payment; }
        }

        #endregion
    }
}
