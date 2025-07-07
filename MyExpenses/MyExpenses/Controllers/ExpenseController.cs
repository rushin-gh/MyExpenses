using Microsoft.AspNetCore.Mvc;
using MyExpenses.Models;

namespace MyExpenses.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            var expenses = new List<Expense>()
            {
                new Expense("Spectacle", "Bought Spectacle Frame", 1300),
                new Expense("Bike repair", "Headlamp cover, Garnish, Leg Guard", 1800),
                new Expense("Raincoat", 149),
                new Expense("Bike wash", "Diesel wash", 120)
            };
            return View(expenses);
        }
    }
}
