using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendCartridges2.Models;

namespace BackendCartridges2
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Reg> Regs { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            //List<Rank> rank = new List<Rank>() {
            //    new Rank() { Name = "Administrator" },
            //    new Rank() { Name = "Employee" },
            //    new Rank() { Name = "Mechanic" },
            //    new Rank() { Name = "Client" }
            //};

            //List<User> users = new List<User>()
            //{
            //    new User() { Login = "test", Password = "123", Mail = "1@dot.com", RankId = 4, RegId = 1 },
            //    new User() { Login = "tes2", Password = "123", Mail = "2@dot.com", RankId = 4, RegId = 2 },
            //    new User() { Login = "tes3", Password = "123", Mail = "3@dot.com", RankId = 4, RegId = 3 },
            //};

            //List<Reg> regs = new List<Reg>()
            //{
            //    new Reg() { RegDate=DateTime.Now, AuthDate=DateTime.Now },
            //    new Reg() { RegDate=DateTime.Now, AuthDate=DateTime.Now },
            //    new Reg() { RegDate=DateTime.Now, AuthDate=DateTime.Now }
            //};

            //Users.AddRange(users);
            //Ranks.AddRange(rank);
            //Regs.AddRange(regs);

            //Console.WriteLine("My output:");
            //foreach (User user in users)
            //{
            //    Console.WriteLine(user);
            //};

            //SaveChanges(); //вот здесь БД ломается из-за дубликатов якобы
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(p => p.Rank).WithMany(t => t.Users).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(p => p.Reg).WithOne(t => t.Users).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rank>().HasMany(p => p.Users).WithOne(t => t.Rank).HasForeignKey(p => p.RankId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reg>().HasOne(p => p.Users).WithOne(t => t.Reg).HasForeignKey<User>(p => p.RegId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
