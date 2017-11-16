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
            var accessToken = "EAACEdEose0cBAFT4WEty8uQvRYH9POHPZAUh0CuAaTACZCgh8fdBToBYFt7HdTCHTZCett0dhC2z3Dbv0nPQWcuDojdY65RZCIEja8jTi2zsSJMLo2twAXoWZBvEwZBobiK6kH30oj9phz7Eee3XZAoo10OKfwgvdNqv54Odw6NyFovFNkgnmzhWWV7oKszCuUZD";
            var facebookModule = new FacebookModule();
            var facebookService = new FacebookService(facebookModule);

            var postOnWallTask = facebookService.PostOnWallAsync(accessToken, "Bonjour AREA");
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