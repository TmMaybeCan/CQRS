using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRSTestApp.Models;

namespace CQRSTestApp.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public async Task<int> SaveChanges() => await base.SaveChangesAsync();
    }
}
