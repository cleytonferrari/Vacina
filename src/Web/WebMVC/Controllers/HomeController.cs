using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IVacinadosRepositorio _vacinadosRepositorio;
        private IMunicipioRepositorio _municipioRepositorio;
        public HomeController(ILogger<HomeController> logger, IVacinadosRepositorio vacinadosRepositorio, IMunicipioRepositorio municipioRepositorio)
        {
            _logger = logger;
            _vacinadosRepositorio = vacinadosRepositorio;
            _municipioRepositorio = municipioRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var tPrimeiraDose =_vacinadosRepositorio.GetTotalDose("1");
            var tSegundaDose = _vacinadosRepositorio.GetTotalDose("2");
            //Janssen
            var tJanssen = await _vacinadosRepositorio.GetPorNomeDaVacina("janssen");

            var viewModel = new IndexHomeViewModel
            {
                TotalPrimeiraDose = await tPrimeiraDose,
                TotalSegundaDose = await tSegundaDose,
                TotalDoseUnica = tJanssen.Count(),
                Municipio = await _municipioRepositorio.GetMunicipio()
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class IndexHomeViewModel
    {
        public int TotalPrimeiraDose { get; set; }
        public int TotalSegundaDose { get; set; }
        public int TotalDoseUnica { get; set; }
        public Municipio Municipio { get; set; }
    }
}
