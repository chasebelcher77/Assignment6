using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment_3.Data
{
    public class Assignment_3Context : IdentityDbContext
    {
        public Assignment_3Context (DbContextOptions<Assignment_3Context> options)
            : base(options)
        {
        }

        public DbSet<MovieModel> Movie { get; set; } 
    }
}

