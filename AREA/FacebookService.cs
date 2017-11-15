using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AREA
{
    public class FacebookService
    {
        private readonly IFacebookWrapper _facebookClient;
        private FacebookWrapper facebookWrapper;

        public FacebookService(IFacebookWrapper facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public FacebookService(FacebookWrapper facebookWrapper)
        {
            this.facebookWrapper = facebookWrapper;
        }

        public async Task PostOnWallAsync(string accessToken, string message)
        {
            await _facebookClient.PostAsync(accessToken, "me/feed", new { message });

        }
    }
}

