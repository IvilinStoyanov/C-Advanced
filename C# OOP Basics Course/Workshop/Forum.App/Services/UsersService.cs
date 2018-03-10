using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
   public class UsersService
    {
        public static SignUpStatus TrySignUser(string username, string password)
        {
            var validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if(!validPassword && !validUsername)
            {
                return SignUpStatus.DetailError;
            }

            var forumData = new ForumData();

            bool userAlreadyExist = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExist)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password, new List<int>() );
                forumData.Users.Add(user);
                forumData.SaveChanges();
            }
            return SignUpStatus.Success;

        }
        
        public static bool TryLoginUsers(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var forumData = new ForumData();
            var userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);
            return userExists;
        }
    }
}
