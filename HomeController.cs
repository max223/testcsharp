using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AREA.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TRY FACEBOOK WRAPPER
            var accessToken = "ACEESS_TOKEN_DE_JOZZ";
            var facebookWrapper = new FacebookWrapper();
            var facebookService = new FacebookService(facebookWrapper);

            var postOnWallTask = facebookService.PostOnWallAsync(accessToken, "Hello from C# .NET Core! SISI L'AREA");
            //Task.WaitAll(postOnWallTask); si je le remet, ça attend vraiment ma task et ça plante, si je l'enleve ça plante pas mais ma requete n'ai pas faites
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}