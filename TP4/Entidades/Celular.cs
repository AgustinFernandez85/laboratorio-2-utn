using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Entidades
{
    [Serializable] //La clase va a ser serializable
    public class Celular : Dispositivos
    {
        #region Atributos
        private EModeloCelulares modelo;
        #endregion

        #region Constructor
        public Celular() : base()
        {

        }
        public Celular(string nombre, int cantidad, float precio, EModeloCelulares modelo) : base(nombre, cantidad, precio)
        {
            this.modelo = modelo;
        }
        #endregion

        #region Propiedades
        public EModeloCelulares Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }
        #endregion

        #region Enumerador
        public enum EModeloCelulares 
        {
            Samsung,
            Nokia,
            Huawei
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribo el metodo mostrar para agregar el modelo en especifico del enumerador de celulares
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Modelo: {this.Modelo}");
            sb.AppendLine("-------------------------");
            return sb.ToString();
        }
        #endregion
    }
}
