using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dominio.Acesso;
using Dominio.Base;
using Dominio.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(ILogger<LoginController> logger, IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;

        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var existe = _usuarioRepositorio.ExisteUsuarioNoBanco();
            if(!existe){
                var user = new Usuario()
                            {
                                Nome = "Administrador",
                                Login = "admin",
                                Senha = "Admin@171099",
                                Email = "admin@email.com",
                                Permissoes = new List<Permissao>
                                {
                                    new Permissao{Chave="administrador",Descricao="Administrador do Sistema"}
                                }
                            };
                //var retorno = user.Valido();
                _usuarioRepositorio.Inserir(user);
                
                TempData["Erro"] = "Neste primeiro acesso use: admin, com a senha Admin@171099";
                return View("login");
            }

            
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validar(string usuario, string senha, string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/importar" : returnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            
            var usuarioLogado = await _usuarioRepositorio.Logar(usuario, senha);
            if (usuarioLogado is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioLogado.Nome),
                    new Claim(ClaimTypes.NameIdentifier, usuarioLogado.Login),
                    new Claim(ClaimTypes.Email, usuarioLogado.Email)
                };
                
                //roles
                foreach (var permissao in usuarioLogado.Permissoes)
                {

                }

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
