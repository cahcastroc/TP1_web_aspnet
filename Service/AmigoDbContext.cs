using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AmigoDbContext : DbContext
    {
        public AmigoDbContext(DbContextOptions<AmigoDbContext> options) : base(options) { }

        public DbSet<Amigo> Amigo { get; set; }

    }
}
