using System;
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
    [Route("api/v1/")]
    [ApiController]
    public class DadosApiController : ControllerBase
    {
        private readonly ILogger<DadosApiController> _logger;
        private IEstatisticaRepositorio _estatisticaRepositorio;
        public DadosApiController(ILogger<DadosApiController> logger, IEstatisticaRepositorio estatisticaRepositorio)
        {
            _logger = logger;
            _estatisticaRepositorio = estatisticaRepositorio;
        }

        [Route("totalporsexo")]
        public async Task<IActionResult> GetTotalPorSexo()
        {
            var tMasculino = _estatisticaRepositorio.TotalPorSexoImunizado("M");
            var tFeminino = _estatisticaRepositorio.TotalPorSexoImunizado("F");
            //Janssen

            var viewModel = new List<SexoDadosViewModel>
            {
                new SexoDadosViewModel { Label = "Masculino", Total = await tMasculino },
                new SexoDadosViewModel { Label = "Feminino", Total = await tFeminino }
            };

            return Ok(viewModel);
        }

        
    }
    public class SexoDadosViewModel
    {
        public int Total { get; set; }
        public string Label { get; set; }
    }
}
