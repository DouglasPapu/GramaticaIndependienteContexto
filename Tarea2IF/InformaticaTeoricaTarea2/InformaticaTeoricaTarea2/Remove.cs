using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformaticaTeoricaTarea2
{
    /// <summary>
    /// Elimina un caracter de una cadena.
    /// </summary>
    public static class Remove
    {
        /// <summary>
        /// Permite eliminar un caracter de un string.
        /// </summary>
        /// <param name="str">
        /// cadena a eliminar el caracter.
        /// </param>
        /// <param name="position">
        /// posicion donde se encuentra el caracter a eliminar.
        /// </param>
        /// <returns>
        /// el string sin el caracter pasado por parametro.
        /// </returns>
        public static string RemoveAt(this String str, int position)
        {
            string srt = "";

            for (int i = 0; i < str.Count(); i++)
            {
                if (i != position)
                {
                    srt = srt + str.ElementAt(i);
                }
            }

            return srt;
        }



    }
}
