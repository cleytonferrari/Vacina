using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IInconsistenciaRepositorio : IRepositorio<Vacinados>
    {
        /// <summary>
        /// Localiza os registro que tem mais de uma dose, porem com nome de vacinas diferentes
        /// </summary>
        /// <returns></returns>
        List<Vacinados> GetDosesDiferentesAplicadasNoMesmoVacinado();

        int GetTotalDosesDiferentesAplicadasNoMesmoVacinado();

        /// <summary>
        /// Localiza os registro que tomaram a segunda dose, porem não tomaram a primeira dose
        /// </summary>
        /// <param name="numeroRegistroNoBanco">Quantos registros devem existir no Banco</param>
        /// <param name="numeroDose">Numero da dose: 1 - Primeira Dose, 2 - Segunda Dose, 8 - Dose Única</param>
        /// <returns></returns>
        Task<List<Vacinados>> GetInconsistenciaNoNumeroDaDoseAplicada(int numeroRegistroNoBanco, string numeroDose);

        Task<int> GetTotalInconsistenciaNoNumeroDaDoseAplicada(int numeroRegistroNoBanco, string numeroDose);

    }
}
