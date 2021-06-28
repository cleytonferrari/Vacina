using System.Collections.Generic;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace EntityInMemory
{
    public class VacinaRepositorio : DbContext
    {

        private VacinaContext _context;
        public VacinaRepositorio()
        {
            var options = new DbContextOptionsBuilder<VacinaContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            _context = new VacinaContext(options);
        }
        
        public void Salvar(Dose dose)
        {
            _context.Doses.Add(dose);
            _context.SaveChanges();
        }

        public IEnumerable<Dose> GetAll()
        {
            return _context.Doses.Include(u => u.Paciente);
        }
    }
}
