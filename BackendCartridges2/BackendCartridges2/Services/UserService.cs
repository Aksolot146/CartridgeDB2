using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendCartridges2.Models;

namespace BackendCartridges2.Services
{
    public class UserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include(x => x.Reg)
                .Include(x => x.Rank)
                .ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void AddUser(User user)
        {
            //login,pwd,mail...

            //Reg reg = new Reg()
            //{
            //    Id = user.Id,
            //    RegDate = DateTime.Now,
            //    AuthDate = DateTime.Now
            //};

            //_context.Regs.Add(reg);

            if (user.RankId == 0)
            {
                user.RankId = 4;
            }

            if (user.RegId == 0)
            {
                user.RegId = user.Id;
            }

            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
