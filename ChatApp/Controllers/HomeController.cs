using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string UserKey = "USER_KEY";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var usernName = HttpContext.Session.GetString(UserKey);

            if (string.IsNullOrEmpty(usernName))
            {
                return RedirectToAction("SignIn");
            }

            var vm = new IndexViewModel
            {
                UserName = usernName
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            SignInUser(viewModel.UserName);

            return RedirectToAction("Index");
        }

        private void SignInUser(string viewModelUserName)
        {
            HttpContext.Session.SetString(key:UserKey,value: viewModelUserName);
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
    }
}