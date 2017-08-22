using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cielo.Enums;
using Cielo.Extensions;
using Newtonsoft.Json;

namespace Cielo.Requests.Entites.Common
{
    public class Customer
    {
        #region private vars

        private readonly Address _address;
        private readonly Address _deliveryAddress;

        #endregion

        #region ctor

        /// <summary>
        /// Customer Information
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="identity">Identity Data</param>
        /// <param name="identityType">Identity Type</param>
        /// <param name="birthdate">Birthday</param>
        /// <param name="address">Address</param>
        /// <param name="deliveryAddress">Deliery Address</param>
        public Customer(string name,
                        string identity = null,
                        CustomerIdentityType identityType = CustomerIdentityType.Default,
                        DateTime? birthdate = null,
                        Address address = null,
                        Address deliveryAddress = null)
        {
            Name = name;
            Identity = identity?.RegexReplace(@"[\/.-]*", String.Empty);
            IdentityType = identityType.ToDescription();
            Birthdate = birthdate.ToCieloShortFormatDate();
            _address = address;
            _deliveryAddress = deliveryAddress;
        }

        #endregion

        #region properties

        public string Name { get; private set; }
        public string Identity { get; private set; }
        public string IdentityType { get; private set; }
        public string Birthdate { get; private set; }
        public Address Address
        {
            get { return _address; }
        }
        public Address DeliveryAddress
        {
            get { return _deliveryAddress; }
        }

        #endregion
    }
}
