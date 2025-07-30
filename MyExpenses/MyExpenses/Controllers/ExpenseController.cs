using Microsoft.AspNetCore.Mvc;
using MyExpenses.Models;
using MyExpenses.Business;
using Org.BouncyCastle.Bcpg;

namespace MyExpenses.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly DBOperations dBOperations;

        public ExpenseController(DBOperations dBOperations)
        {
            this.dBOperations = dBOperations;
        }

        public IActionResult Index()
        {

            var expenses = dBOperations.GetExpenses(1); // Assuming userId is 1 for demonstration purposes
            return View(expenses);
        }

        public IActionResult ShowExpenses()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            var expenses = dBOperations.GetExpenses(userId);
            return View(expenses);
        }

        [HttpGet]
        public IActionResult AddExpense()
        {
            return View(new Expense());
        }

        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            dBOperations.AddExpense(userId, expense);
            return RedirectToAction("ShowExpenses");
        }

        public ActionResult UpdateExpense(int expenseId)
        {
            Expense expense = dBOperations.GetExpenseById(expenseId);
            return View(expense);
        }

        //public ActionResult UpdateExpense(Expense expense)
        //{
        //    //dBOperations.UpdateExpense(expense);
        //    return View();

        //}
    }
}