using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Cielo.Responses.Exceptions
{
    public class ErrorResponse
    {
        public ErrorResponse(string content, HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = HttpStatusCode;

            if (!String.IsNullOrWhiteSpace(content))
            {
                JArray response = JArray.Parse(content);

                Id = (string)response[0]["Code"];
                Message = (string)response[0]["Message"];
            }
        }

        public string Id { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }
    }
}
