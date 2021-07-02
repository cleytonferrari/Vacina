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
        private readonly IVacinadosRepositorio _vacinadosRepositorio;

        public ImportarController(ILogger<ImportarController> logger, IWebHostEnvironment env, IVacinadosRepositorio vacinadosRepositorio)
        {
            _logger = logger;
            _env = env;
            _vacinadosRepositorio = vacinadosRepositorio;
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
                var vacinadosCSV = ProcessarVacinadosCSV.Get(nomeDoArquivo);

                servicoArquivo.ExcluirArquivoDoDisco(nomeDoArquivo);

                if (vacinadosCSV == null)
                {
                    ViewBag.Mensagem = "Erro: O arquivo enviado para a Importação não é válido!";
                    return View();
                }

                #region Verifica Duplicados
                var vacinadosDuplicados = new List<Vacinados>();
                var vacinadosNovos = new List<Vacinados>();

                foreach (var itemCSV in vacinadosCSV)
                {
                    var vacinado = new Vacinados();
                    vacinado.Doses.Add(itemCSV.Dose);
                    vacinado.Pessoa = itemCSV.Pessoa;
                    vacinado.GrupoDeAtendimento = itemCSV.GrupoDeAtendimento;

                    var vacinadoBanco = _vacinadosRepositorio.GetPorCNSouCPF(itemCSV.Pessoa.CNS, itemCSV.Pessoa.CPF);
                    if (vacinadoBanco != null)
                    {
                        if (!vacinadoBanco.Doses.Any(x => x.NumeroDose == itemCSV.Dose.NumeroDose))
                        {
                            vacinadoBanco.Doses.Add(itemCSV.Dose);
                            _vacinadosRepositorio.Atualizar(vacinadoBanco);
                        }
                    }
                    else
                        _vacinadosRepositorio.Inserir(vacinado);

                }
                #endregion

                ViewBag.Mensagem = $"O arquivo [ {vm.Arquivo.FileName} ] com {vacinadosCSV.ToList().Count} registros, foi processados com sucesso!";
            }

            return View();
        }


    }
}
