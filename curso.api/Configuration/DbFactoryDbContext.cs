using curso.api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Configuration
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<CursoDbContext>();
            options.UseSqlServer("Data Source=DESKTOP-N030KT1\\SQLEXPRESS;Initial Catalog=Curso;Trusted_Connection=true;Integrated Security=true", b => b.MigrationsAssembly("curso.api"));
            CursoDbContext context = new CursoDbContext(options.Options);

            return context;
        }
    }
}
