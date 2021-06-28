using Dominio.Repositorio;
using System;

namespace Dominio
{
    //paciente_nome;paciente_enumSexoBiologico;paciente_dataNascimento;
    public class Pessoa : EntidadeBase
    {
        
        public string Nome { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
