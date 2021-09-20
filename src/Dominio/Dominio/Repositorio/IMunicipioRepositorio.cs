using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IMunicipioRepositorio : IRepositorio<Municipio>
    {
        Task<Municipio> GetMunicipio();

    }
}
