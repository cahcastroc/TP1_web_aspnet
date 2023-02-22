using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PessoaDbContextFactory : IDesignTimeDbContextFactory<PessoaDbContext>
    {
        public PessoaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PessoaDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\xmorn\\source\\repos\\TP1_web_aspnet\\aniversario_db.mdf;Integrated Security=True;Connect Timeout=30");
            return new PessoaDbContext(optionsBuilder.Options);
        }
    }
}
