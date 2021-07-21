using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio.Extensions
{

    public static class StringExtension
    {

        public static string RemoverEspacosExtras(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return ConverteEspacosEmEspacoUnico(str).Trim();
        }
        /// <summary>
        /// Remove espaços e caracteres especiais
        /// </summary>
        /// <param name="str">string que sera limpa</param>
        /// <returns>string limpa</returns>
        public static string Limpar(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            HashSet<char> removeChars = new HashSet<char>("?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder resultado = new StringBuilder(str.Length);
            foreach (char c in str)
                if (!removeChars.Contains(c))
                    resultado.Append(c);
            return RemoverEspacosExtras(resultado.ToString());
        }


        public static string SomenteAsIniciaisDoNome(this string str)
        {
            var meio = " ";
            var nomes = str.Split(' ');
            for (var i = 1; i < nomes.Length; i++)
            {
                if (!nomes[i].Equals("de", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("da", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("do", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("das", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("dos", StringComparison.OrdinalIgnoreCase))
                    meio += nomes[i][0] + ". ";
            }
            return nomes[0] + meio;
        }

        private static string ConverteEspacosEmEspacoUnico(string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
    }
}
