using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyExpenses.Models;


namespace MyExpenses.Business
{
    public class DBOperations
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DBOperations(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:MyExpenseDB"];
        }

        public List<Expense> GetExpenses(int? userId)
        {
            var expenses = new List<Expense>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("GetUserExpenses", sqlConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = Convert.ToInt32(reader["ExpenseId"]);
                            var title = reader["Title"].ToString();
                            var desc = reader["Desc"].ToString();
                            var amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                            expenses.Add(new Expense(id, title, desc, amount));
                        }
                    }
                }
            }

            return expenses;
        }

        public void Login(User user)
        {
            if (IsValidUser(user))
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("GetUserId", sqlConnection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", user.Username);

                        user.UserId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }

        public bool IsValidUser(User user)
        {
            string hashedPassword = string.Empty;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("GetHashedPassword", sqlConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);

                    var scalarResult = cmd.ExecuteScalar();
                    if (scalarResult != null)
                    {
                        hashedPassword = scalarResult.ToString();
                    }
                }
            }

            return string.IsNullOrWhiteSpace(hashedPassword)
                    ? false 
                    : BCrypt.Net.BCrypt.Verify(user.Password, hashedPassword); ;
        }

        public void RegisterUser (User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("RegisterUser", sqlConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", GetHashedPassword(user.Password));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string GetHashedPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public void AddExpense(int? userId, Expense expense)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("AddExpense", sqlConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", expense.Title);
                    cmd.Parameters.AddWithValue("@Desc", expense.Desc);
                    cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
