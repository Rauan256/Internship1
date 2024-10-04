using Microsoft.EntityFrameworkCore;
using Internship.Models;
using System.Collections.Generic;


namespace Internship.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
