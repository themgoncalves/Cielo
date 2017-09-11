using System;
using System.Net;
using Cielo.Configuration;
using Cielo.Extensions;
using Cielo.Requests;
using Cielo.Requests.Entites;
using Cielo.Responses;
using Cielo.Responses.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Cielo
{
    public class CieloService : ICieloService
    {
        #region private vars

        protected internal readonly IConfiguration Configuration;
        private RestClient client = new RestClient();

        #endregion

        #region ctor

        public CieloService(IConfiguration configuration = null)
        {
            if (configuration == null) configuration = new DefaultConfiguration();
            this.Configuration = configuration;
        }

        #endregion

        #region methods

        /// <summary>
        /// Create a new Transaction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NewTransactionResponse CreateTransaction(TransactionRequest request)
        {
            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.DefaultEndpoint,
                method = Method.POST,
                resource = "1/sales/",
                body = request
            };

            return Execute<NewTransactionResponse>(param);
        }

        /// <summary>
        /// Create a new Eletronic Transfer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EletronicTransferResponse CreateEletronicTransfer(TransactionRequest request)
        {
            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.DefaultEndpoint,
                method = Method.POST,
                resource = "1/sales/",
                body = request
            };

            return Execute<EletronicTransferResponse>(param);
        }

        /// <summary>
        /// Cancel a transaction
        /// </summary>
        /// <param name="paymentId">Payment transaction Id</param>
        /// <param name="merchantOrderId">Order Id</param>
        /// <returns></returns>
        public TransactionResponse CancelTransaction(Guid? paymentId = null, string merchantOrderId = null, decimal amount = 0)
        {
            if (paymentId == null && String.IsNullOrWhiteSpace(merchantOrderId))
                throw new ArgumentNullException("In order to proceed with the cancellation, you must provide the 'paymentId' or 'merchantOrderId'");

            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.DefaultEndpoint,
                method = Method.PUT,
                resource = (amount == 0 ? 
                (paymentId != null ? $"/1/sales/{paymentId}/void" : $"/1/sales/OrderId/{merchantOrderId}/void") :
                (paymentId != null ? $"/1/sales/{paymentId}/void?amount={amount}" : $"/1/sales/OrderId/{merchantOrderId}/void?amount={amount}"))
            };

            return Execute<TransactionResponse>(param);
        }
        
        /// <summary>
        /// Capture a transaction
        /// </summary>
        /// <param name="paymentId">Payment transaction Id</param>
        /// <param name="amount">Amount to capture. Leave empty if it is total.</param>
        /// <returns></returns>
        public TransactionResponse CaptureTransaction(Guid paymentId, decimal amount = 0)
        {
            int partialCapture = (int)(amount * 100);
            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.DefaultEndpoint,
                method = Method.PUT,
                resource = $"/1/sales/{paymentId}/capture" + (partialCapture > 0 ? $"?amount={partialCapture}" : "")
            };

            return Execute<TransactionResponse>(param);
        }

        /// <summary>
        /// Check transaction
        /// </summary>
        /// <param name="paymentId">Payment transaction Id</param>
        /// <param name="merchantOrderId">Order Id</param>
        /// <returns></returns>
        public CheckTransactionResponse CheckTransaction(Guid? paymentId = null, string merchantOrderId = null)
        {
            if (paymentId == null && String.IsNullOrWhiteSpace(merchantOrderId))
                throw new ArgumentNullException("In order to proceed with the cancellation, you must provide the 'paymentId' or 'merchantOrderId'");

            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.QueryEndpoint,
                method = Method.GET,
                resource = (paymentId != null ? $"/1/sales/{paymentId}" : $"/1/sales?merchantOrderId={merchantOrderId}")
            };

            return Execute<CheckTransactionResponse>(param);
        }

        /// <summary>
        /// Save a card
        /// </summary>
        /// <param name="request">Card Information</param>
        /// <returns></returns>
        public CardResponse SaveCard(CreditCardRequest request)
        {
            RequestParams param = new RequestParams()
            {
                baseUrl = Configuration.DefaultEndpoint,
                method = Method.POST,
                resource = "/1/card/",
                body = request
            };

            return Execute<CardResponse>(param);
        }


        /// <summary>
        /// Execute a Web Request
        /// </summary>
        /// <param name="requestParam">Request parameters</param>
        /// <returns>Class</returns>
        protected virtual T Execute<T>(RequestParams requestParam) where T : class
        {
            try
            {
                client.BaseUrl = new Uri(requestParam.baseUrl);
                var request = new RestRequest(requestParam.resource.CleanPathUrl(requestParam.baseUrl), requestParam.method);

                #region parameters

                if (requestParam.param != null)
                {
                    foreach (Parameter p in requestParam.param)
                    {
                        request.AddParameter(p);
                    }
                }
                #endregion adding parameters

                #region authentication methods

                request.AddParameter("MerchantId", Configuration.MerchantId, ParameterType.HttpHeader);
                request.AddParameter("MerchantKey", Configuration.MerchantKey, ParameterType.HttpHeader);
                request.AddParameter("RequestId", Guid.NewGuid(), ParameterType.HttpHeader);

                #endregion authentication

                #region header request params

                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;

                #endregion

                if (requestParam.body != null)

                    request.AddParameter("application/json",
                           JsonConvert.SerializeObject(requestParam.body, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                           ParameterType.RequestBody);

                var response = client.Execute(request);

                if ((response.StatusCode != HttpStatusCode.Created) &&
                    (response.StatusCode != HttpStatusCode.OK))
                {
                    throw new ResponseException(new ErrorResponse(response.Content, response.StatusCode));
                }

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (ResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}