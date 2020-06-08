using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Registro_de_Usuario.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Entidades.Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlite(@"Data source = Data\Usuarios.db");
        }
    }
}
