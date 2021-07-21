namespace Dominio
{
    public class Endereco : Entidade
    {
        public string Municipio { get; set; } //paciente_endereco_nmMunicipio
        public string UF { get; set; } //paciente_endereco_uf
        public string Bairro { get; set; } //paciente_endereco_bairro
    }
}
