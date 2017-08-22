using Cielo.Enums;
using Cielo.Extensions;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class CreditCard : ICard, ICardToken
    {
        #region private vars

        private readonly CardExpiration _expiration;

        #endregion

        #region ctor

        /// <summary>
        /// Credit card information.
        /// </summary>
        /// <param name="cardToken">Saved Card Token</param>
        /// <param name="securityCode">Card's Secutiry Code</param>
        /// <param name="cardBrand">Card Brand</param>
        public CreditCard(string cardToken,
                         string securityCode,
                         CardBrand cardBrand)
        {
            CardToken = cardToken;
            SecurityCode = securityCode;
            Brand = cardBrand.ToDescription();
        }

        /// <summary>
        /// Credit card information.
        /// </summary>
        /// <param name="cardNumber">Card Number</param>
        /// <param name="holder">Card's Holder Name</param>
        /// <param name="expirationDate">Card's Expiration Date</param>
        /// <param name="securityCode">Card's Secutiry Code</param>
        /// <param name="cardBrand">Card Brand</param>
        /// <param name="saveCard">Save Card</param>
        public CreditCard(string cardNumber,
                         string holder,
                         CardExpiration expirationDate,
                         string securityCode,
                         CardBrand cardBrand,
                         bool saveCard = false)
        {
            CardNumber = cardNumber.ToNumbers();
            Holder = holder;
            _expiration = expirationDate;
            SecurityCode = securityCode;
            Brand = cardBrand.ToDescription();
            SaveCard = saveCard;
        }

        #endregion

        #region properties

        public string CardToken { get; private set; }
        public string CardNumber { get; private set; }
        public string Holder { get; private set; }
        public string ExpirationDate
        {
            get { return _expiration?.ToString(); }
        }
        public string SecurityCode { get; private set; }
        public string Brand { get; private set; }
        public bool SaveCard { get; private set; }

        #endregion
    }
}
