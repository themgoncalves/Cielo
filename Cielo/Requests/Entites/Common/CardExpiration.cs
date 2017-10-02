using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class CardExpiration
    {
        #region private vars

        private readonly byte _month;
        private readonly short _year;

        #endregion

        #region ctor

        /// <summary>
        /// Card Expiration date
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        public CardExpiration(short year, byte month)
        {
            if ((short)DateTime.Now.Year >= year && (byte)DateTime.Now.Month > month) 
                throw new Exception("Card Expiration Date is invalid");

            _year = year;
            _month = month;
        }

        #endregion

        #region override methods

        public override string ToString()
        {
            var monthAsString = _month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            return string.Format("{0}/{1}", monthAsString, _year);
        }

        #endregion
    }
}
