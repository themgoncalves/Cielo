using System.Collections.Generic;
using RestSharp;

namespace Cielo.Request
{
    public class RequestParams
    {
        public string baseUrl { get; set; }
        public Method method { get; set; }
        public string resource { get; set; }
        public List<Parameter> param { get; set; }
        public object body { get; set; }
    }
}
