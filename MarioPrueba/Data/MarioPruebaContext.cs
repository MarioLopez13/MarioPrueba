using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarioPrueba.Models;

namespace MarioPrueba.Data
{
    public class MarioPruebaContext : DbContext
    {
        public MarioPruebaContext (DbContextOptions<MarioPruebaContext> options)
            : base(options)
        {
        }

        public DbSet<MarioPrueba.Models.MLopez> MLopez { get; set; } = default!;
    }
}
