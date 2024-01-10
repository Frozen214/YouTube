using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_1
{
    public class PersonalData
    {
        public static int IdUser { get; private set; }
        public static string Password { get; private set; }
        public static string Login { get; private set; }
        public static string Role { get; private set; }
        public static string LastName { get; private set; }
        public static string FirstName { get; private set; }
        public static string FatherName { get; private set; }
        public static string DateBrth { get; private set; }
        public static string NumberTel { get; private set; }

        public bool SetPersonalData(string login, string password)
        {
            var db = new DB();

            string sqlExpression = " select top 1 * from Сотрудники с  " +
                                   " INNER JOIN Пользователи п ON с.[ID Пользователя] = п.[ID Пользователя] " +
                                   " WHERE п.Логин = @Login and п.Пароль = @Password ";

            using (SqlConnection connection = new SqlConnection(db.StringCon))
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
                            NumberTel = reader["Номер телефона"].ToString();
                            FirstName = reader["Фамилия"].ToString();
                            LastName = reader["Имя"].ToString();
                            FatherName = reader["Отчество"].ToString();
                            DateBrth = DateTime.Parse(reader["Дата рождения"].ToString()).ToString("yyyy-MM-dd");
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
