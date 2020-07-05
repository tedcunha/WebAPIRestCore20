using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> persons { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
