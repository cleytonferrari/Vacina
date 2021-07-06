using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Base
{
    public static class ValidarExtension
    {
        public static ObjetoRetorno<T> Valido<T>(this T entidade) where T: Entidade
        {
            var objetoRetorno = new ObjetoRetorno<T>();
            var resultados = new List<ValidationResult>();
            //this - entidade
            var isvalid = Validator.TryValidateObject(entidade, new ValidationContext(entidade, null, null), resultados, true);

            if (!isvalid)
            {
                foreach (var item in resultados)
                {
                    foreach (var r in item.MemberNames)
                        objetoRetorno.AdicionaUmErro(typeof(T).Name + "." + r, item.ErrorMessage);
                }
                objetoRetorno.TemErro = true;
            }
            return objetoRetorno;
        }
    }
}
