using Microsoft.AspNetCore.Mvc;
using OceanicAirlinesWebApp.Models;
using System.Diagnostics;

namespace OceanicAirlinesWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.Password == objuserlogin.Password).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "CORRECT UserName and Password";
                return Redirect("/Parcels/Create");
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";
            }
            return View(objuserlogin);
        }

        public List<LoginModel> Userloginvalues()
        {
            List<LoginModel> objModel = new List<LoginModel>();
            objModel.Add(new LoginModel { UserName = "Mr Ambassador", Password = "noTaxPlz" });
            return objModel;
        }

        public bool isSessionInvalid()
        {
            return HttpContext.Session.GetString(SessionName) == "_Name";

        }
    }
}