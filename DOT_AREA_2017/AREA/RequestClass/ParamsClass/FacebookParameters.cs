using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA
{
    public class FacebookParameters : RequestParam
    {
        internal object data;
        private string message;

        public FacebookParameters(string accessToken, string endpoint, object data, string message = null)
        {
            this.accessToken = accessToken;
            this.endpoint = endpoint;
            this.data = data;
            this.message = message;
        }

        public string endpoint { get; set;}
        public string accessToken { get; set; }
        public string args{ get; set;}

    }
}