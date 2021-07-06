using Dominio.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Acesso
{
    public class Usuario : Entidade
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = Mensagens.Usuario.OLoginInformadoNaoValido)]
        [Required(ErrorMessage = Mensagens.Usuario.OLoginInformadoNaoValido)]
        public string Login { get; set; }

        [Required(ErrorMessage = Mensagens.Senha.SenhaRequerida)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20}", ErrorMessage = Mensagens.Senha.SenhaDeveSerForte)]
        public string Senha { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }

    }
}
