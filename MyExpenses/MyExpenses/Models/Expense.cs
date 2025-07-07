namespace MyExpenses.Models
{
    public class Expense
    {
        public string Title { get; set; }

        public string Desc { get; set; }

        public decimal Amount { get; set; }

        public Expense(string title, string desc, decimal amount)
        {
            Title = title;
            Desc = desc;
            Amount = amount;
        }

        public Expense(string title, decimal amount) : this(title, string.Empty, amount) { }
    }
}
