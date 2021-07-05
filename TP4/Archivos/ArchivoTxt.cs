using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Expeciones;
namespace Archivos
{
    public class ArchivoTxt : IArchivos<string>
    {
        /// <summary>
        /// Guarda un archivo de texto en la ruta especificada
        /// </summary>
        /// <param name="ruta">es el path del archivo</param>
        /// <param name="datos">son los datos a escribir</param>
        /// <returns>devuelve true si se pudo guardar y false si no</returns>
        public bool Guardar(string ruta, string datos)
        {
            try
            {
                if (!String.IsNullOrEmpty(datos) && !String.IsNullOrEmpty(ruta))
                {
                    using (StreamWriter sw  = new StreamWriter(ruta,false))
                    {
                        sw.WriteLine(datos);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException("Error al guardar el archivo", e);
            }
            return false;
        }
        /// <summary>
        /// Lee un archivo de texto y escribe sus datos en una variable string
        /// </summary>
        /// <param name="ruta">es el path del archivo</param>
        /// <param name="datos">en esta variable escribimos el contenido del archivo</param>
        /// <returns>retorna true si se pudo leer y false en caso contrario</returns>
        public bool Leer(string ruta, out string datos)
        {
            try
            {
                datos = String.Empty;
                if (File.Exists(ruta))
                {
                    using (StreamReader sr = new StreamReader(ruta,Encoding.UTF8))
                    {
                        datos = sr.ReadToEnd();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer el archivo de texto", e);
            }
            return false;
        }
    }
}
