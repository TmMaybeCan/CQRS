using CQRSTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSTestApp.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}