using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
        /// <summary>
        /// Se encarga de sacar el stock total de la lista de dispositivos
        /// </summary>
        /// <param name="listaDispositivos">la lista de dispositivos a ser contada</param>
        /// <returns>retorna un stringbuilder con la cantidad de dispositivos total, y de cada uno</returns>
        public static string StockTotal(this List<Dispositivos> listaDispositivos) 
        {
            int contadorCelulares = 0;
            int contadorNotebooks = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"El stock total es de {listaDispositivos.Count}");
            foreach (Dispositivos item in listaDispositivos)
            {
                if (item is Celular)
                {
                    contadorCelulares += 1;
                }
                else if (item is Notebook)
                {
                    contadorNotebooks += 1;
                }
            }
            sb.AppendLine($"Hay un total de {contadorNotebooks} Notebooks");
            sb.AppendLine($"Hay un total de {contadorCelulares} Celulares");

            return sb.ToString();
        }
    }
}
