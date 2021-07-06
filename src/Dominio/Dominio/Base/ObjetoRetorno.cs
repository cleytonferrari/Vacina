using System.Collections.Generic;

namespace Dominio.Base
{
    public struct Erro
    {
        public string Chave { get; set; }

        public string Valor { get; set; }
    }

    public class ObjetoRetorno<T> where T : class
    {
        public ObjetoRetorno()
        {
            ListaErros = new List<Erro>();
            TemErro = false;
        }

        public List<Erro> ListaErros { get; private set; }

        public T Retorno { get; private set; }

        public bool TemErro { get; set; }

        public ObjetoRetorno<T> AdicionaUmErro(string chave, string mesagemDeErro)
        {
            ListaErros.Add(new Erro
            {
                Chave = chave,
                Valor = mesagemDeErro
            });
            TemErro = true;
            return this;
        }

        public ObjetoRetorno<T> AdicionaUmErro(string mesagemDeErro)
        {
            return AdicionaUmErro("", mesagemDeErro);
        }

        public ObjetoRetorno<T> SetRetorno(T retorno)
        {
            Retorno = retorno;
            return this;
        }
    }
}
