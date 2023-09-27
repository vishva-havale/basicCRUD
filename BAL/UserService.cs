using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UserService : IUserService
    {
        public readonly IUserRepo userRepo;
        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public User AddUser(User user)
        {
            var result=userRepo.AddUser(user);
            return result;
        }
    }
}
