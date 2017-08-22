using Cielo.Extensions;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class Address
    {
        #region ctor

        /// <summary>
        /// Address Information
        /// </summary>
        /// <param name="street">Street</param>
        /// <param name="number">Number</param>
        /// <param name="complement">Complement</param>
        /// <param name="zipCode">Zip Code</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="country">Country</param>
        public Address(string street,
            string number,
            string complement,
            string zipCode,
            string city,
            string state,
            string country = "BRA")
        {
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode.ToNumbers();
            City = city;
            State = state;
            Country = country.ToString();
        }

        #endregion

        #region properties

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        #endregion
    }
}
