using Dominio.Extensions;
using System;

namespace Dominio
{
    public class Pessoa : Entidade
    {
        public string CNS { get; set; }//paciente_cns
        public string CPF { get; set; }//paciente_cpf
        public string Nome { get; set; }//paciente_nome
        public string Sexo { get; set; }//paciente_enumSexoBiologico
        public string NomeMae { get; set; }//paciente_nome_mae
        public DateTime DataNascimento { get; set; }//paciente_dataNascimento

        public Endereco Endereco { get; set; }

        public string NomeAbreviado
        {
            get
            {
                return !string.IsNullOrEmpty(Nome) ? Nome.SomenteAsIniciaisDoNome() : string.Empty;
            }
        }

    }
}
