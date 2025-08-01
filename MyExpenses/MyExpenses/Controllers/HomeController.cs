using Microsoft.AspNetCore.Mvc;
using MyExpenses.Business;
using MyExpenses.Models;
using System.Diagnostics;

namespace MyExpenses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBOperations _dbOperations;

        public HomeController(ILogger<HomeController> logger, DBOperations dbOperations)
        {
            _logger = logger;
            _dbOperations = dbOperations;
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

        public ActionResult Login(User user)
        {
            _dbOperations.Login(user);
            if (user.UserId > 0)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("ShowExpenses", "Expense");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Register(User user)
        {
            _dbOperations.RegisterUser(user);
            return RedirectToAction("Index");
        }
    }
}
