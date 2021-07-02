using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
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

        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPorPagina = 20; //TODO: Buscar isso do appsettings
            int numeroPagina = (pagina ?? 1);

            var vacinados = await _vacinadosRepositorio.Todos();
            return View(vacinados.OrderBy(x => x.Pessoa.Nome).ToPagedList(numeroPagina, itensPorPagina));
        }

    }
}
