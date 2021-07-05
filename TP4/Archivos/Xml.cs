using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Expeciones;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Este metodo es el encargado de guardar un archivo de tipo xml
        /// </summary>
        /// <param name="ruta">es el path donde quiero que se ubique el archivo xml</param>
        /// <param name="datos">es el objeto a ser serializado</param>
        /// <returns>retorna true si pudo hacer el archivo, false caso contrario</returns>
        public bool Guardar(string ruta, T datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(ruta))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(ruta, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(writer,datos);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {                                  
                throw new Exception(e.Message);
                //throw new ArchivosException("Error al escribir un archivo xml", e);
            }
            return false;
        }

        /// <summary>
        /// Este metodo es el encargado de leer un archivo xml
        /// </summary>
        /// <param name="ruta">es el path donde se encuentra ese archivo</param>
        /// <param name="datos">es donde voy a guardar el objeto que lea</param>
        /// <returns>retorna true si se puede leer, false caso contrario</returns>
        public bool Leer(string ruta, out T datos)
        {
            datos = default(T);
            try
            {
                if (!String.IsNullOrEmpty(ruta))
                {
                    if (File.Exists(ruta))
                    {
                        using (XmlTextReader reader = new XmlTextReader(ruta))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            datos = (T)serializer.Deserialize(reader);
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer un archivo xml", e);
            }
            return false;
        }
    }
}
