using System;
using System.Collections.Generic;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace EntityInMemory
{
    public class VacinaRepositorio : DbContext
    {

        public void Salvar(Dose dose)
        {
            var options = new DbContextOptionsBuilder<VacinaContext>()
            .UseInMemoryDatabase(databaseName: "Test").Options;
            var context = new VacinaContext(options);

            context.Doses.Add(dose);
            context.SaveChanges();
        }

        public IEnumerable<Dose> GetAll()
        {
            var options = new DbContextOptionsBuilder<VacinaContext>()
            .UseInMemoryDatabase(databaseName: "Test").Options;
            var context = new VacinaContext(options);

            return context.Doses.Include(u => u.Paciente);
        }
    }
}
