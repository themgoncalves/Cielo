using Cielo.Enums;
using Cielo.Extensions;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class DebitCard : ICard
    {
        #region private vars

        private readonly CardExpiration _expiration;

        #endregion

        #region ctor

        /// <summary>
        /// Debit card information.
        /// </summary>
        /// <param name="cardNumber">Card Number</param>
        /// <param name="holder">Card's Holder Name</param>
        /// <param name="expirationDate">Card's Expiration Date</param>
        /// <param name="securityCode">Card's Secutiry Code</param>
        /// <param name="cardBrand">Card Brand</param>
        public DebitCard(string cardNumber,
                         string holder,
                         CardExpiration expirationDate,
                         string securityCode,
                         CardBrand cardBrand)
        {
            CardNumber = cardNumber.ToNumbers();
            Holder = holder;
            _expiration = expirationDate;
            SecurityCode = securityCode;
            Brand = cardBrand.ToDescription();
        }

        #endregion

        #region properties

        public string CardNumber { get; private set; }
        public string Holder { get; private set; }
        public string ExpirationDate
        {
            get { return _expiration.ToString(); }
        }
        public string SecurityCode { get; private set; }
        public string Brand { get; private set; }

        #endregion
    }
}
