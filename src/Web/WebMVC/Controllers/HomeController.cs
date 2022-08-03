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
            /*
                    Primeira dose - 1
                    Segunda dose - 2
                    Dose unica - 8
                    Dose unica - 9
                    Dose Reforço - 38
                    2ª Dose Reforço - 7
                    3ª Dose Reforço - 39
                    Dose Adicional - 37
             */

            var tPrimeiraDose =_vacinadosRepositorio.GetTotalDose("1");
            var tSegundaDose = _vacinadosRepositorio.GetTotalDose("2");
            var tDoseReforco = _vacinadosRepositorio.GetTotalDose("38");
            var tSegundaDoseReforco = _vacinadosRepositorio.GetTotalDose("7");
            var tTerceiraDoseReforco = _vacinadosRepositorio.GetTotalDose("39");
            var tDoseAdicional = _vacinadosRepositorio.GetTotalDose("37");
            var tDoseUnica = _vacinadosRepositorio.GetTotalDose("8");
            var tVacinasAplicadas = _vacinadosRepositorio.GetTotalDose();

            var viewModel = new IndexHomeViewModel
            {
                TotalPrimeiraDose = await tPrimeiraDose,
                TotalSegundaDose = await tSegundaDose,
                TotalDoseUnica = await tDoseUnica, 
                TotalDoseReforco = await tDoseReforco,
                TotalSegundaDoseReforco = await tSegundaDoseReforco,
                TotalTerceiraDoseReforco= await tTerceiraDoseReforco,
                TotalDoseAdicional = await tDoseAdicional,
                TotalVacinasAplicadas =  await tVacinasAplicadas,
                Municipio = await _municipioRepositorio.GetMunicipio() ?? new Municipio()
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
        public int TotalDoseReforco { get; set; }
        public int TotalSegundaDoseReforco { get; set; }
        public int TotalTerceiraDoseReforco { get; set; }
        public int TotalDoseAdicional { get; set; }
        public int TotalVacinasAplicadas { get; set; }
        public Municipio Municipio { get; set; }
    }
}
