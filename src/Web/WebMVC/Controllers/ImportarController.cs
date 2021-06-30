using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
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
                var vacinadosCSV = ProcessarDoseCSV.Get(nomeDoArquivo);
                
                servicoArquivo.ExcluirArquivoDoDisco(nomeDoArquivo);

                if (vacinadosCSV == null)
                {
                    ViewBag.Mensagem = "Erro: O arquivo enviado para a Importação não é válido!";
                    return View();
                }

                #region Verifica Duplicados
                var vacinadosBanco = await _doseRepositorio.Todos();

                var vacinadosDuplicados = new List<Dose>();
                var vacinadosNovos = new List<Dose>();

                foreach (var item in vacinadosCSV)
                {
                    if (vacinadosBanco.Any(
                        x => x.Paciente.Nome == item.Paciente.Nome
                        && x.NumeroDose == item.NumeroDose
                        && x.DataAplicacao.ToShortDateString() == item.DataAplicacao.ToShortDateString()))
                    {
                        vacinadosDuplicados.Add(item);
                    }
                    else
                    {
                        vacinadosNovos.Add(item);
                    }
                }
                #endregion

                msg = $"O arquivo [ {vm.Arquivo.FileName} ] com {vacinadosCSV.ToList().Count} registros foi processados com sucesso!";
                if (vacinadosNovos.Any())
                {
                    await _doseRepositorio.Inserir(vacinadosNovos);
                    msg += $"<br /> - {vacinadosNovos.ToList().Count} novos registros foram importados!";
                }
                if (vacinadosDuplicados.Any())
                    msg += $"<br /> - {vacinadosDuplicados.ToList().Count} registros duplicados, não foram importados!";

                ViewBag.Mensagem = msg;
            }

            return View();
        }


    }
}
