using System;
using Cielo.Enums;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class Payment
    {
        #region private vars

        private readonly CreditCard _creditCard;
        private readonly DebitCard _debitCard;

        #endregion

        #region ctor

        /// <summary>
        /// Payment Information
        /// </summary>
        /// <param name="type">Type. Eg: CredictCard, DebitCard, Eletronic Transfer, etc.</param>
        /// <param name="amount">Total purchase value</param>
        /// <param name="provider">Provider name</param>
        /// <param name="returnUrl">Url which user will be redirect after finish the payment process.</param>
        public Payment(PaymentType type,
                       decimal amount,
                       EletronicTransferProvider provider,
                       string returnUrl)
        {
            Type = type.ToString();
            Amount = (int)(amount * 100);
            Provider = provider.ToString();
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// Payment Information
        /// </summary>
        /// <param name="type">Type. Eg: CredictCard, DebitCard, Eletronic Transfer, etc.</param>
        /// <param name="amount">Total purchase value</param>
        /// <param name="installments">Installments</param>
        /// <param name="softDescriptor">Text to be printed in the Bank Invoice</param>
        /// <param name="capture">Should capture payment</param>
        /// <param name="authenticate">Should redirect to the Bank to authenticate card.</param>
        /// <param name="returnUrl">Url which user will be redirect after finish the payment process.</param>
        /// <param name="creditCard">Credit Card Information</param>
        /// <param name="debitCard">Debit Card Information</param>
        public Payment(PaymentType type,
                       decimal amount,
                       byte installments,
                       string softDescriptor,
                       bool capture = false,
                       bool authenticate = false,
                       string returnUrl = null,
                       CreditCard creditCard = null,
                       DebitCard debitCard = null)
        {
            Type = type.ToString();
            Amount = (int)(amount * 100);
            Installments = installments;
            SoftDescriptor = softDescriptor;
            Capture = capture;
            Authenticate = Authenticate;
            ReturnUrl = returnUrl;

            if (type == PaymentType.CreditCard)
                if (creditCard == null)
                    throw new ArgumentNullException(paramName: nameof(creditCard), message: "Your CreditCard information cannot be null.");
                else
                    _creditCard = creditCard;

            else if (type == PaymentType.DebitCard)
                if (debitCard == null)
                    throw new ArgumentNullException(paramName: nameof(debitCard), message: "Your DebitCard information cannot be null.");
                else
                    _debitCard = debitCard;
        }

        #endregion

        #region properties

        public string Type { get; private set; }
        public int Amount { get; private set; }
        public byte Installments { get; private set; }
        public string SoftDescriptor { get; private set; }
        public bool Capture { get; private set; }
        public bool Authenticate { get; private set; }
        public string Provider { get; private set; }
        public string ReturnUrl { get; private set; }
        public CreditCard CreditCard
        {
            get { return _creditCard; }
        }
        public DebitCard DebitCard
        {
            get { return _debitCard; }
        }

        #endregion
    }
}
