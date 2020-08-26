using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pogged.Web.Controllers
{
    [Route("controllers/[controller]")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            Console.WriteLine("load: Home");
            return Json(new { success = true });
        }
    }
}
