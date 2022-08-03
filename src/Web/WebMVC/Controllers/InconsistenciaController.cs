using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dominio;
using Dominio.Extensions;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using X.PagedList;

namespace WebMVC.Controllers
{
    public class InconsistenciaController : Controller
    {
        private readonly ILogger<VacinadosController> _logger;
        private IInconsistenciaRepositorio _inconsistenciaRepositorio;
        public InconsistenciaController(ILogger<VacinadosController> logger, IInconsistenciaRepositorio inconsistenciaRepositorio)
        {
            _logger = logger;
            _inconsistenciaRepositorio = inconsistenciaRepositorio;
        }

        public async Task<IActionResult> Index(int? pagina, int opcao)
        {
            var tDosesDiferentesNoMesmoVacinado = _inconsistenciaRepositorio.GetDosesDiferentesAplicadasNoMesmoVacinado();
            var tNoNumeroDaDoseAplicada = _inconsistenciaRepositorio.GetTotalInconsistenciaNoNumeroDaDoseAplicada(1, "2");



            var viewModel = new IndexInconsistenciaViewModel
            {
                TotalDosesDiferentesNoMesmoVacinado = tDosesDiferentesNoMesmoVacinado.Count,
                TotalNoNumeroDaDoseAplicada = await tNoNumeroDaDoseAplicada,
                DosesDiferentes = _inconsistenciaRepositorio.GetDosesDiferentes()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Listar(int? pagina, int opcao)
        {
            const int itensPorPagina = 20; //TODO: Buscar isso do appsettings
            var titulo = "";
            List<Vacinados> vacinados; ;// = new List<Vacinados>();

            if (opcao == 1)
            {
                vacinados = _inconsistenciaRepositorio.GetDosesDiferentesAplicadasNoMesmoVacinado();
                titulo = "Vacina aplicada na 1ª Dose difere da vacina aplicada na 2ª Dose";
            }
            else
            {
                vacinados = await _inconsistenciaRepositorio.GetInconsistenciaNoNumeroDaDoseAplicada(1, "2");
                titulo = "Vacinado somente com a 2ª dose";
            }

            var viewModel = new ListarInconsistenciaViewModel
            {
                Vacinados = vacinados.OrderBy(x => x.Pessoa.Nome).ToPagedList(pagina ?? 1, itensPorPagina),
                TituloPagina = titulo
            };

            return View(viewModel);
        }

    }


    public class IndexInconsistenciaViewModel
    {
        public int TotalDosesDiferentesNoMesmoVacinado { get; set; }
        public int TotalNoNumeroDaDoseAplicada { get; set; }
        public Dictionary<string,string> DosesDiferentes { get; set; }
    }

    public class ListarInconsistenciaViewModel
    {
        public IPagedList<Dominio.Vacinados> Vacinados { get; set; }
        public string TituloPagina { get; set; }
    }
}
