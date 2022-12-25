using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendCartridges2.Models;
using BackendCartridges2.Services;
using Microsoft.EntityFrameworkCore;

namespace BackendCartridges2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
    {
        UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public int Add(User user)
        {
            _userService.AddUser(user);
            return user.Id;
        }

        [HttpDelete]
        public void Remove(User user)
        {
            _userService.DeleteUser(user);
        }

        [HttpPut]
        public void Update(User user)
        {
            _userService.UpdateUser(user);
        }
    }
}
