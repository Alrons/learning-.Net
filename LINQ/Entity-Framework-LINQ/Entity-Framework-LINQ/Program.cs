using Entity_Framework_LINQ.EntityModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace Entity_Framework_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User newUser = new User() { Name = "NewUserName2", Age = 24 };
            //Console.WriteLine("___________________________________________");
            //AddUser(newUser);
            //GetAllUsers();
            //Console.WriteLine("___________________________________________");
            //GetUsersByFilter(u => u.Age < 25);
            //Console.WriteLine("___________________________________________");
            //GetOrderByUsers(u => u.Age);
            //Console.WriteLine("___________________________________________");
            //EditUsersPlusAge(newUser);
            //Console.WriteLine("___________________________________________");
            //SQLUser("SELECT \"Id\", \"Name\", \"Age\"\r\n\tFROM public.\"User\" WHERE \"Age\" > 20");
        }

        // получаем список пользователей
        public static List<User> GetAllUsers ()
        {
            List < User > users = new List<User> ();
            using (var context = new AppDbContext())
            {
                users = context.User.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name + " Age: " + user.Age);
                }
            }
            return users;
        }

        // добовляем пользователя
        public static void AddUser(User user)
        {
            using (var context = new AppDbContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        // получаем пользователя по булевому условию (например: u => u.Age < 30)
        public static void GetUsersByFilter (Func<User,bool> func)
        {
            using (var context = new AppDbContext())
            {
                var users = context.User.Where(func).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name + " Age: " + user.Age);
                }
            }
        }

        // выводим отсортированных пользователей
        public static void GetOrderByUsers<TKey>(Func<User, TKey> func)
        {
            using (var context = new AppDbContext())
            {
                var users = context.User.OrderBy(func).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name + " Age: " + user.Age);
                }
            }
        }


        // добавляем пользователю 1 год
        public static void EditUsersPlusAge(User oneUser)
        {
            using (var context = new AppDbContext())
            {
                var user = context.User.FirstOrDefault(u => u.Name == oneUser.Name);
                if (user != null)
                {
                    user.Age++;
                    context.SaveChanges();
                }
                else Console.WriteLine("UserNotFound");
            }
        }

        // удаляем польователя
        public static void DeleteUser (User oneUser)
        {
            using (var context = new AppDbContext())
            {
                var user = context.User.FirstOrDefault(u => u.Name == oneUser.Name);
                if (user != null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        // получаем пользователя через SQL
        public static void SQLUser(string query)
        {
            using (var context = new AppDbContext())
            {
                var users = context.User.FromSqlRaw(query).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name + " Age: " + user.Age);
                }
            }
        }
    }
}
