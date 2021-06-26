using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityInMemory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositorioCSV;
using WebMVC.Models;
using WebMVC.Servicos;

namespace WebMVC.Controllers
{
    public class ImportarController : Controller
    {

        private readonly ILogger<ImportarController> _logger;
        private readonly IWebHostEnvironment _env;

        public ImportarController(ILogger<ImportarController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] ImportarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var servicoArquivo = new ServicoArquivo(_env);
                var fileName = servicoArquivo.Upload(vm.Arquivo);
                //teste
                var repositorio = new DoseRepositorio();
                var vacinados = repositorio.Get(fileName);
                servicoArquivo.ApagarArquivo(fileName);

                 var repositorioInMemory = new VacinaRepositorio();
                 foreach (var item in vacinados)
                 {
                     repositorioInMemory.Salvar(item);
                 }
                //fim

                ViewBag.Mensagem = "Arquivo adicionado!";
            }

            return View();
        }


    }
}
