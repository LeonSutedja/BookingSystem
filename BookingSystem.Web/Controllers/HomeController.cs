using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace BookingSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BookingSystemControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}