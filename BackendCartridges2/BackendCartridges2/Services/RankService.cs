using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendCartridges2.Models;

namespace BackendCartridges2.Services
{
    public class RankService
    {
        private readonly ApplicationContext _context;

        public RankService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Rank> GetRanks()
        {
            _context.Users.Load();

            return _context.Ranks.ToList();
        }

        public Rank GetRank(int id)
        {
            return _context.Ranks.FirstOrDefault(x => x.Id == id);
        }
    }
}
