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
                string msg;
                var servicoArquivo = new ServicosDeArquivos(_env);
                var nomeDoArquivo = servicoArquivo.Upload(vm.Arquivo);
                var vacinados = ProcessarDoseCSV.Get(nomeDoArquivo);

                if (vacinados != null)
                {
                    await _doseRepositorio.Inserir(vacinados);
                    msg = $"O arquivo [ {vm.Arquivo.FileName} ] com {vacinados.ToList().Count} registros foi processados com sucesso!";
                }
                else
                    msg = "Erro: O arquivo enviado para a Importação não é válido!";

                servicoArquivo.ExcluirArquivoDoDisco(nomeDoArquivo);

                ViewBag.Mensagem = msg;
            }

            return View();
        }


    }
}
