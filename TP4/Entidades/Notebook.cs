using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Entidades
{
    [Serializable]
    public class Notebook : Dispositivos 
    {
        #region Atributos
        private EModeloNotebook modelo;
        #endregion

        #region Constructores
        public Notebook() : base()
        {

        }
        public Notebook(string nombre, int cantidad, float precio, EModeloNotebook modelo) : base(nombre,cantidad, precio)
        {
            this.modelo = modelo;
        }
        #endregion

        #region Propiedades
        public EModeloNotebook Modelo
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
        public enum EModeloNotebook 
        {
            HP,
            Mac,
            Thinkpad
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobreescribo el metodo mostrar para cargar el enumerador de su respectivo modelo en el stringbuilder
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
