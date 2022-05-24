using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filme.Entity;
using Microsoft.EntityFrameworkCore;

namespace filme.Helper
{
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt){

        }
        public DbSet<Filme> Filmes {get; set;}
    }
}