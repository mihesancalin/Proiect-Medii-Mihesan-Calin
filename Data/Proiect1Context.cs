using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect1.Models;

namespace Proiect1.Data
{
    public class Proiect1Context : DbContext
    {
        public Proiect1Context (DbContextOptions<Proiect1Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect1.Models.Film> Film { get; set; }

        public DbSet<Proiect1.Models.Producator> Producator { get; set; }

        public DbSet<Proiect1.Models.Category> Category { get; set; }
    }
}
