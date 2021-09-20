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
        private IMunicipioRepositorio _municipioRepositorio;
        public DadosApiController(ILogger<DadosApiController> logger, IEstatisticaRepositorio estatisticaRepositorio, IMunicipioRepositorio municipioRepositorio)
        {
            _logger = logger;
            _estatisticaRepositorio = estatisticaRepositorio;
            _municipioRepositorio = municipioRepositorio;
        }

        [Route("totalporsexo")]
        public async Task<IActionResult> GetTotalPorSexo()
        {
            var tMasculino = _estatisticaRepositorio.TotalPorSexoImunizado("M");
            var tFeminino = _estatisticaRepositorio.TotalPorSexoImunizado("F");
          
            var viewModel = new List<ChartDadosViewModel>
            {
                new ChartDadosViewModel { Label = "Masculino", Total = await tMasculino },
                new ChartDadosViewModel { Label = "Feminino", Total = await tFeminino }
            };

            return Ok(viewModel);
        }

        [Route("totalimunizado")]
        public async Task<IActionResult> GetTotalImunizado()
        {
            var tImunizados = _estatisticaRepositorio.TotalImunizado();

            //buscar do ibge https://servicodados.ibge.gov.br/api/v3/agregados/6579/periodos/2020/variaveis/9324?localidades=N6[1100403]
            var municipio = await _municipioRepositorio.GetMunicipio();
            var tPopulacao = municipio.PopulacaoIBGE;

            var viewModel = new List<ChartDadosViewModel>
            {
                new ChartDadosViewModel { Label = "Imunizados", Total = await tImunizados },
                new ChartDadosViewModel { Label = "População", Total =  tPopulacao }
            };

            return Ok(viewModel);
        }


    }
    public class ChartDadosViewModel
    {
        public int Total { get; set; }
        public string Label { get; set; }
    }
}
