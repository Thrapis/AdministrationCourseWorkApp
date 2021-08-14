using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.Statement
{
    public class RequestManager
    {
        HttpRequestBase Request;

        public RequestManager(HttpRequestBase request)
        {
            Request = request;
        }

        public string GetParamValue(string name)
        {
            return Request.Params.Get(name);
        }

        public bool HasParamValue(string name)
        {
            return Request.Params.AllKeys.Contains(name);
        }

        public string GetHeaderValue(string name)
        {
            return Request.Headers.Get(name);
        }

        public bool HasHeaderValue(string name)
        {
            return Request.Headers.AllKeys.Contains(name);
        }
    }
}