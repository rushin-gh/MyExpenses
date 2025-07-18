﻿using Microsoft.AspNetCore.Mvc;
using MyExpenses.Models;
using MyExpenses.Business;

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

            var expenses = new DBOperations(new ConfigurationManager()).GetExpenses(1); // Assuming userId is 1 for demonstration purposes
            return View(expenses);
        }

        public IActionResult ShowExpenses(int userId)
        {
            var expenses = dBOperations.GetExpenses(userId);
            return View(expenses);
        }
    }
}
