using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmankulovMidtermB.Models;
using System.Security.Cryptography.X509Certificates;

namespace SmankulovMidtermB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   
    }
        public DbSet<Taco> Taco { get; set; }
    }

   
}