using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Kiritek", PasswordHash = "7aa9ca453fdaec228bc18b649d6b63cfe74a4ce4098d30908c73000210b6b594",Role = "Admin" }
        };

        public User GetByUsernameAndPassword(string username, string password)
        {
            var passwordHasher = new PasswordHasher();
            var user = _users.SingleOrDefault(u => u.Name == username &&
                u.PasswordHash == passwordHasher.HashWithSHA256(password));
            return user;
        }
    }
}
