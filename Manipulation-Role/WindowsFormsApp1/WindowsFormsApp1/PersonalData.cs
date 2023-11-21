using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class PersonalData
    {
        public static int IdUser { get; private set; }
        public static string Password { get; private set; }
        public static string Login { get; private set; }
        public static string Role { get; private set; }

        public bool SetPersonalData(string login, string password) 
        {
            var db = new DB(); 

            string sqlExpression = "SELECT TOP 1 * FROM Пользователи WHERE Логин = @Login AND Пароль = @Password";

            using (SqlConnection connection = new SqlConnection(db.stringCon()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            IdUser = (int)reader["ID Пользователя"];
                            Role = reader["Роль"].ToString();
                            Login = reader["Логин"].ToString();
                            Password = reader["Пароль"].ToString();
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}