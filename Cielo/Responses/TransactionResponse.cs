using System.Collections.Generic;
using System.Runtime.Serialization;
using Cielo.Enums;
using Cielo.Extensions;
using Newtonsoft.Json;

namespace Cielo.Responses
{
    public class TransactionResponse
    {
        #region private vars

        [JsonExtensionData]
        private IDictionary<string, object> _response;

        #endregion

        #region ctor

        public TransactionResponse()
        {
            _response = new Dictionary<string, object>();
        }

        #endregion
                
        #region methods

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Status = EnumExtension.ToEnum<Status>(_response["Status"]?.ToString());
            ReturnCode = EnumExtension.ToEnum<ReturnCode>(_response["ReturnCode"]?.ToString());
            ReturnMessage = _response["ReturnMessage"]?.ToString();
        }

        #endregion

        #region properties
        
        public Status Status { get; private set; }
        public ReturnCode ReturnCode { get; private set; }
        public string ReturnMessage { get; private set; }

        #endregion
    }
}
