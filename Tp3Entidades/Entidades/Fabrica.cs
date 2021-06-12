using Expeciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Notebook))]
    [XmlInclude(typeof(Celular))]
    public sealed class Fabrica
    {
        #region Atributos
        private List<Dispositivos> listaDispositivos;
        #endregion

        #region Constructores
        public Fabrica()
        {
            this.listaDispositivos = new List<Dispositivos>();
        }
        #endregion

        #region Propiedades
        public List<Dispositivos> ListaDispositivos
        {
            get 
            {
                return this.listaDispositivos;
            }
            set 
            {
                this.listaDispositivos = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega un dispositivo a la lista de la fabrica
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="dispo"></param>
        /// <returns>retorna true si puede, false caso contrario</returns>
        public static bool operator +(Fabrica fabrica, Dispositivos dispo) 
        {
            if (!fabrica.ListaDispositivos.Contains(dispo))
            {
                fabrica.ListaDispositivos.Add(dispo);
                return true;
            }
            else 
            {
                throw new DispositivoRepetidoException("El Dispositivo que quiere agregar ya fue agregado anteriormente");
            }
        }
        /// <summary>
        /// Esta sobrecarga de operador es para quitar 1 dispositivo de la lista
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="dispo"></param>
        /// <returns>retorna true si lo pudo quitar y false caso contrario</returns>
        public static bool operator -(Fabrica fabrica, Dispositivos dispo) 
        {
            foreach (Dispositivos item in fabrica.ListaDispositivos)
            {
                if (item == dispo)
                {
                    fabrica.ListaDispositivos.Remove(item);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Este metodo calcula el stock total de cada dispositivo y lo suma en total
        /// </summary>
        /// <returns>retorna un stringbuilder exponiendo la cantidad total, cantidad de notebooks y de celulares</returns>
        public string CalcularStock() 
        {
            int contadorCelulares = 0;
            int contadorNotebooks = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"El stock total es de {this.listaDispositivos.Count}");
            foreach (Dispositivos item in this.listaDispositivos)
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
        /// <summary>
        /// Aca aplicamos polimorfismo para poder sobreescribir el tostring y qeu recorra la lista de dispositivos mientras voy mostrando sus descripciones
        /// </summary>
        /// <returns>devuelve un stringbuilder cargado con cada descripcion de todos los dispositivos en la lista</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dispostivos: ");
            foreach (Dispositivos item in ListaDispositivos)
            {
                sb.AppendLine(item.Mostrar());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Es el metodo que llama a la clase XML para serializar esta misma clase y hacer el archivo xml
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns>retorna true si se pudo hacer, false caso contrario</returns>
        public static bool Guardar(Fabrica fabrica) 
        {
            string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Fabrica.xml");
            Xml<Fabrica> fabricaAux = new Xml<Fabrica>();
            return fabricaAux.Guardar(path, fabrica);
        }
        #endregion
    }
}
