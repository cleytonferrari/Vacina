using Dominio.Repositorio;
using System;

namespace Dominio
{
    public class Pessoa : EntidadeBase
    {
        public string CNS { get; set; }//paciente_cns
        public string CPF { get; set; }//paciente_cpf
        public string Nome { get; set; }//paciente_nome
        public string Sexo { get; set; }//paciente_enumSexoBiologico
        public string NomeMae { get; set; }//paciente_nome_mae
        public DateTime DataNascimento { get; set; }//paciente_dataNascimento

    }
}
