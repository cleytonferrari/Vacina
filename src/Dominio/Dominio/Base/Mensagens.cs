namespace Dominio.Base
{
    public class Mensagens
    {
        public struct Usuario
        {
            public const string LoginInvalido = "O Usuário/Senha não são válidos!";
            public const string OLoginInformadoNaoValido = "O login deve possuir no minimo 5 caracteres!";
        }

        public struct Senha
        {
            public const string SenhaDeveSerForte = "A senha deve conter Letras Maiusculas e Minusculas, Números ou Caracteres especiais, e no minimo 5 caracteres.";
            public const string SenhaRequerida = "Preencha a Senha do Usuário.";
        }
    }
}
