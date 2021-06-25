using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                var fileName =  servicoArquivo.Upload(vm.Arquivo);
                TempData["message"] = "Successfully Added";
            }
            
            return RedirectToAction("Index");
        }


    }
}
