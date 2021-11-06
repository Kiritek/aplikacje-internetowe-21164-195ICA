using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
    }
}
