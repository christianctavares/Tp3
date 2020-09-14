using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tp3.Models;

namespace Tp3.Data
{
    public class Tp3Context : DbContext
    {
        public Tp3Context (DbContextOptions<Tp3Context> options)
            : base(options)
        {
        }

        public DbSet<Tp3.Models.Amigo> Amigo { get; set; }
    }
}
