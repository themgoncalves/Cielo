using System;
using System.Collections.Generic;
using System.Linq;
using Cielo.Enums;
using Cielo.Extensions;
using Cielo.Requests.Entites.Common;

namespace Cielo.Requests.Entites
{
    public class CreditCardRequest
    {
        #region private vars

        private readonly CardExpiration _expiration;

        #endregion

        #region ctor

        /// <summary>
        /// Credit card information.
        /// </summary>
        /// <param name="customerName">Customer Name</param>
        /// <param name="cardNumber">Card Number</param>
        /// <param name="holder">Card's Holder Name</param>
        /// <param name="expirationDate">Card's Expiration Date</param>
        /// <param name="cardBrand">Card Brand</param>
        public CreditCardRequest(string customerName,
                         string cardNumber,
                         string holder,
                         CardExpiration expirationDate,
                         CardBrand cardBrand)
        {
            CustomerName = customerName;
            CardNumber = cardNumber.ToNumbers();
            Holder = holder;
            _expiration = expirationDate;
            Brand = cardBrand.ToDescription();
        }

        #endregion

        #region properties

        public string CustomerName { get; private set; }
        public string CardNumber { get; private set; }
        public string Holder { get; private set; }
        public string ExpirationDate
        {
            get { return _expiration.ToString(); }
        }
        public string Brand { get; private set; }

        #endregion
    }
}
