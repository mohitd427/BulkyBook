using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //THis will crate table in database with name Categories
        public DbSet<Category> Categories { get; set; }
    }
}
