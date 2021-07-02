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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validar(string usuario, string senha, string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/importar" : returnUrl;
            ViewData["ReturnUrl"] = returnUrl;
            if (usuario == "admin" && senha == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim("usario", usuario),
                    new Claim(ClaimTypes.NameIdentifier, usuario),
                    new Claim(ClaimTypes.Name, "Administrador"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData["Erro"] = "Erro! Usuário ou Senha inválidos!";
            return View("login");
        }

        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
