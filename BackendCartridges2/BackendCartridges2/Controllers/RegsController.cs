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
    public class RegsController
    {
        RegService _registrationService;

        public RegsController(RegService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public IEnumerable<Reg> Get()
        {
            return _registrationService.GetRegs();
        }

        [HttpGet("{id}")]
        public Reg Get(int id)
        {
            return _registrationService.GetRegistration(id);
        }

        [HttpPost]
        public int Add(Reg registration)
        {
            _registrationService.AddRegistration(registration);
            return registration.Id;
        }

        [HttpDelete]
        public void Remove(Reg registration)
        {
            _registrationService.DeleteRegistration(registration.Id);
        }

        [HttpPut]
        public void Update(Reg registration)
        {
            _registrationService.UpdateRegistration(registration);
        }
    }
}
