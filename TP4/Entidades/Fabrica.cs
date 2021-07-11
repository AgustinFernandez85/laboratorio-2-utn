using Expeciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;
using System.Threading;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Notebook))]
    [XmlInclude(typeof(Celular))]
    public sealed class Fabrica
    {
        #region Atributos
        public delegate void DelegadoHarcodeo();
        public event DelegadoHarcodeo miEventoHarcodeo;
        private List<Dispositivos> listaDispositivos;
        #endregion

        #region Constructores
        public Fabrica()
        {
            miEventoHarcodeo += this.HarcodearProductos;
            this.listaDispositivos = new List<Dispositivos>();
        }
        #endregion

        #region Propiedades
        public List<Dispositivos> ListaDispositivos
        {
            get 
            {
                return DispositivoDAO.LeerTodo();
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
            if (!DispositivoDAO.CompararDispositivo(dispo))
            {
                DispositivoDAO.InsertarDispositivo(dispo);
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
                    DispositivoDAO.DeleteDispositivo(dispo.Nombre);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Con esta sobrecarga valido que 2 listas de dispositivos sean las mismas, lo uso en los unit test
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="fabrica2"></param>
        /// <returns></returns>
        public static bool operator ==(Fabrica fabrica, Fabrica fabrica2)
        {
            for (int i = 0; i < fabrica.listaDispositivos.Count; i++)
            {
                if (fabrica.listaDispositivos[i] != fabrica2.listaDispositivos[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// lo contrario al ==
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="fabrica2"></param>
        /// <returns></returns>
        public static bool operator !=(Fabrica fabrica, Fabrica fabrica2)
        {
            return !(fabrica == fabrica2);
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
            sb.AppendLine($"El stock total es de {this.ListaDispositivos.Count}");
            foreach (Dispositivos item in this.ListaDispositivos)
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
        public void HarcodearProductos() 
        {
            if (miEventoHarcodeo != null)
            {
                Dispositivos d1 = new Notebook("notebook1", 24, 44444, Notebook.EModeloNotebook.HP);
                Dispositivos d2 = new Notebook("notebook2", 32, 66666, Notebook.EModeloNotebook.Mac);
                Dispositivos d3 = new Notebook("notebook3", 64, 1111, Notebook.EModeloNotebook.Thinkpad);
                Dispositivos d4 = new Celular("Celular1", 234, 44444, Celular.EModeloCelulares.Huawei);
                Dispositivos d5 = new Celular("Celular2", 224, 123123, Celular.EModeloCelulares.Nokia);
                Dispositivos d6 = new Celular("Celular3", 1, 55555, Celular.EModeloCelulares.Samsung);

                this.ListaDispositivos.Add(d1);
                this.ListaDispositivos.Add(d2);
                this.ListaDispositivos.Add(d3);
                this.ListaDispositivos.Add(d4);
                this.ListaDispositivos.Add(d5);
                this.ListaDispositivos.Add(d6);
            }
        }
        /// <summary>
        /// Harcodea 3 dispositivos para ser usado el metodo en un hilo
        /// </summary>
        /// <param name="f">es la fabrica en cuestion</param>
        public static void AgregarNotebooksAProduccion(object f) 
        {
            try
            {
                Dispositivos d1 = new Notebook("HP 2233", 24, 44444, Notebook.EModeloNotebook.HP);
                Dispositivos d2 = new Notebook("MacBook", 32, 66666, Notebook.EModeloNotebook.Mac);
                Dispositivos d3 = new Notebook("ThinkPad 2233", 64, 1111, Notebook.EModeloNotebook.Thinkpad);

                if (((Fabrica)f - d1) && ((Fabrica)f - d2) && ((Fabrica)f - d3))
                {
                    Console.WriteLine("Me encargo de eliminar si es que quedaron agregados de alguna ejecucion anterior");
                }

                if (((Fabrica)f + d1) && ((Fabrica)f + d2) && ((Fabrica)f + d3)) 
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Se Agrego 3 nuevas notebook a produccion desde el hilo {Thread.CurrentThread.Name}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Harcodea celulares y es usado por otro hilo
        /// </summary>
        /// <param name="f">fabrica en cuestion</param>
        public static void AgregarCelularesAProduccion(object f)
        {
            try
            {
                Fabrica fabrica = (Fabrica)f;
                Dispositivos d1 = new Celular("Huawei 123123123", 234, 44444, Celular.EModeloCelulares.Huawei);
                Dispositivos d2 = new Celular("Nokia 22222", 224, 123123, Celular.EModeloCelulares.Nokia);
                Dispositivos d3 = new Celular("Samsung 2233", 1, 55555, Celular.EModeloCelulares.Samsung);

                if ((fabrica - d1) && (fabrica - d2) && (fabrica - d3)) 
                {
                    Console.WriteLine("Me encargo de eliminar si es que quedaron agregados de alguna ejecucion anterior");
                }

                if ((fabrica + d1) && (fabrica + d2) && (fabrica + d3))
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Se Agrego 3 nuevos celulares a produccion desde el hilo {Thread.CurrentThread.Name}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
