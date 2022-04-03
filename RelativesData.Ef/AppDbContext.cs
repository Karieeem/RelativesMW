using Microsoft.EntityFrameworkCore;
using RelativesData.Core.Models;
using RelativesData.Ef.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoPattern2.Ef
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Relative> Relative { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
