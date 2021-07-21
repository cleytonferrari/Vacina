using System.Collections.Generic;
using System.Linq;
using Dominio.Extensions;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace WebMVC.Controllers
{
    public class VacinadosController : Controller
    {
        private readonly ILogger<VacinadosController> _logger;
        private IVacinadosRepositorio _vacinadosRepositorio;
        public VacinadosController(ILogger<VacinadosController> logger, IVacinadosRepositorio vacinadosRepositorio)
        {
            _logger = logger;
            _vacinadosRepositorio = vacinadosRepositorio;
        }

        public IActionResult Index(int? pagina, string busca = "", string dose = "", string grupo = "")
        {
            const int itensPorPagina = 20; //TODO: Buscar isso do appsettings
            busca = busca.Limpar();
            dose = dose.Limpar();
            grupo = grupo.Limpar();

            var vacinados = _vacinadosRepositorio.Buscar();

            if (!string.IsNullOrEmpty(busca))
                vacinados = vacinados.Where(x => x.Pessoa.Nome.ToLower().Contains(busca.ToLower()));

            if (!string.IsNullOrEmpty(dose))
                vacinados = vacinados.Where(x => x.Doses.Any(y => y.NumeroDose.ToLower() == dose.ToLower()) );
            
            if (!string.IsNullOrEmpty(grupo))
                vacinados = vacinados.Where(x=>x.GrupoDeAtendimento.Nome.ToLower() == grupo.ToLower());

            var viewModel = new IndexVacinadosViewModel
            {
                GrupoDeAtendimento = _vacinadosRepositorio.GetGruposDeAtendimento().Result.ToList(),
                Vacinados = vacinados.OrderBy(x => x.Pessoa.Nome).ToPagedList(pagina ?? 1, itensPorPagina)
            };

            return View(viewModel);
        }

    }

    

    public class IndexVacinadosViewModel
    {
        public IPagedList<Dominio.Vacinados> Vacinados { get; set; }
        public List<Dominio.GrupoDeAtendimento> GrupoDeAtendimento { get; set; }
    }
}
