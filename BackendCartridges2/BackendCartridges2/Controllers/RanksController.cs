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
    public class RanksController
    {
        RankService _rankService;

        public RanksController(RankService rankService) 
        {
            _rankService = rankService;
        }

        [HttpGet]
        public IEnumerable<Rank> Get()
        {
            return _rankService.GetRanks();
        }

        [HttpGet("{id}")]
        public Rank Get(int id)
        {
            return _rankService.GetRank(id);
        }
    }
}
