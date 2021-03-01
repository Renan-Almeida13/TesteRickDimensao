using Microsoft.EntityFrameworkCore;
using RickDimensao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class RickDimensaoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=renanrickdimensao.csvxxt1f2sbh.us-east-2.rds.amazonaws.com,3306;uid=admin;pwd=admin1234;database=UniversoRick", b => b.MigrationsAssembly("UniversoRick"));
        }

        public DbSet<Rick> Rick { get; set; }

        public DbSet<Universo> Universo { get; set; }
    }
}
