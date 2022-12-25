using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendCartridges2.Models;

namespace BackendCartridges2.Services
{
    public class RegService
    {
        private readonly ApplicationContext _context;

        public RegService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Reg> GetRegs()
        {
            _context.Users.Load();

            return _context.Regs.ToList();
        }

        public Reg GetRegistration(int id)
        {
            return _context.Regs.FirstOrDefault(x => x.Id == id);
        }

        public void AddRegistration(Reg reg)
        {
            _context.Regs.Add(reg);
            _context.SaveChanges();
        }

        public void DeleteRegistration(int id)
        {
            Reg reg = GetRegistration(id);
            _context.Regs.Remove(reg);
            _context.SaveChanges();
        }

        public void UpdateRegistration(Reg registration)
        {
            _context.Regs.Update(registration);
            _context.SaveChanges();
        }
    }
}
