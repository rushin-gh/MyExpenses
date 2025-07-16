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

        public List<Expense> GetExpenses(int userId)
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
                            var title = reader["Title"].ToString();
                            var desc = reader["Desc"].ToString();
                            var amount = reader.GetInt32(reader.GetOrdinal("Amount"));
                            expenses.Add(new Expense(title, desc, amount));
                        }
                    }
                }
            }

            return expenses;
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
    }
}
