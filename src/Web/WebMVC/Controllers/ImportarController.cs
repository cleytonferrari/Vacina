using System.Linq;
using System.Threading.Tasks;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositorioCSV;
using WebMVC.Models;
using WebMVC.Servicos;

namespace WebMVC.Controllers
{
    [Authorize]
    public class ImportarController : Controller
    {

        private readonly ILogger<ImportarController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IDoseRepositorio _doseRepositorio;

        public ImportarController(ILogger<ImportarController> logger, IWebHostEnvironment env, IDoseRepositorio doseRepositorio)
        {
            _logger = logger;
            _env = env;
            _doseRepositorio = doseRepositorio;
        }
        
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Importar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Importar([FromForm] ImportarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var servicoArquivo = new ServicosDeArquivos(_env);
                var nomeDoArquivo = servicoArquivo.Upload(vm.Arquivo);
                
                //TODO: Validar campos do arquivo CSV
                var vacinados = ProcessarDoseCSV.Get(nomeDoArquivo);
                servicoArquivo.ExcluirArquivoDoDisco(nomeDoArquivo);
                
                await _doseRepositorio.Inserir(vacinados);
                
                ViewBag.Mensagem = $"O arquivo [ {vm.Arquivo.FileName} ] com {vacinados.ToList().Count()} registros foi processados com sucesso!";
            }

            return View();
        }


    }
}
