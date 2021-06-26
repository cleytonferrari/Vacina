using System;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace EntityInMemory
{
    public class VacinaContext : DbContext
    {
        public VacinaContext(DbContextOptions<VacinaContext> options)
          : base(options)
        {}
        public DbSet<Dose> Doses { get; set; }
    }
}
