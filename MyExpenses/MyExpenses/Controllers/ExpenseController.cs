using Microsoft.AspNetCore.Mvc;
using MyExpenses.Models;
using MyExpenses.Business;

namespace MyExpenses.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            var expenses = new DBOperations(new ConfigurationManager()).GetExpenses(1); // Assuming userId is 1 for demonstration purposes
            return View(expenses);
        }
    }
}
