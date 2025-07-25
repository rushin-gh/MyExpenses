namespace MyExpenses.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public decimal Amount { get; set; }

        public Expense() { }

        public Expense(int id, string title, string desc, decimal amount)
        {
            Id = id;
            Title = title;
            Desc = desc;
            Amount = amount;
        }

        public Expense(int id, string title, decimal amount) : this(id, title, string.Empty, amount) { }
    }
}
