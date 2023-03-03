using InMemory_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace InMemory_MVC.DAL
{
    public static class UserRepository
    {
        static UserRepository()
        {
            using (var userDbContext = new UserDbContext())
            {
                AddUser(userDbContext, 1, "Moacir", "moacir@email.com", "123456");
                AddUser(userDbContext, 2, "Maria", "maria@email.com", "123456");
                AddUser(userDbContext, 3, "Carol", "carol@email.com", "123456");

                userDbContext.SaveChanges();
            }
        }

        private static void AddUser(UserDbContext userDbContext, int id, string name, string email, string password)
        {
            userDbContext.Users.Add(new UserModel()
            {
                Id = id,
                Name = name,
                Email = email,
                Password = password
            });
        }

        public static List<UserModel> ListUser()
        {
            using (var userDbContext = new UserDbContext())
            {
                return userDbContext.Users.OrderBy(c => c.Name).ToList();
            }
        }

        public static void DeleteUser()
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Remove(userDbContext.Users.FirstOrDefault());
                userDbContext.SaveChanges();
            }
        }
    }
}