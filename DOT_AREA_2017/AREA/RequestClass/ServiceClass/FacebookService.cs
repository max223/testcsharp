using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AREA
{
    public class FacebookService : AService
    {

            public FacebookService(AModule module) : base(module)
        {
            _module = _module as FacebookModule;
               
        }
        
        public async Task PostOnWallAsync(string accessToken, string message)
        {
            FacebookParameters _params = new FacebookParameters(accessToken,"me/feed", new {message});
            await _module.PostAsync(_params); 
        }
     }
}

