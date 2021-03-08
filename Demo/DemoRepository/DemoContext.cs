using DemoData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        public DbSet<Login> tblLogin { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<Domain> tblDomainData { get; set; }
    }
}
