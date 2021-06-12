using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Dispositivos
    {
        #region Atributos
        protected string nombre;
        protected int cantidad;
        protected float precio;
        #endregion

        #region Constructores
        /// <summary>
        /// En el constructor sin parametros pongo los valores en default
        /// </summary>
        public Dispositivos()
        {
            this.nombre = string.Empty;
            this.cantidad = -1;
            this.precio = -1;
        }

        public Dispositivos(string nombre, int cantidad, float precio) : this()
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el nombre y para setear valido que el nombre no sea null y tenga un minimo de length
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarModelo(value);
            }
        }
        /// <summary>
        /// Devuelvo la cantidad y valido que para setear sea mayor o igual a 1 por lo menos
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                if (value >= 1)
                {
                    this.cantidad = value;
                }
            }
        }
        /// <summary>
        /// Devuelvo el precio y valido que para setear sea mayor o igual a 1 por lo menos
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value >= 1)
                {
                    this.precio = value;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// En este metodo valido que no sea nullo o este vacio y que su largo sea mayor a 1 por lo menos
        /// </summary>
        /// <param name="dato">Es la cadena de texto a ser recibida</param>
        /// <returns>Retorno la cadena en caso de que pase la validacion y si no retorno "Desconcido"</returns>
        private string ValidarModelo(string dato)
        {
            if (!string.IsNullOrEmpty(dato) && dato.Length > 1)
            {
                return dato;
            }
            return "Desconocido";
        }
        /// <summary>
        /// Sobreescribo el tostring de Dispositivo donde muestro sus atributos y los devuelvo en una cadena
        /// </summary>
        /// <returns>retorna la cadena de texto con sus atributos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Cantidad: {this.Cantidad}");
            sb.AppendLine($"Precio: {this.Precio}");

            return sb.ToString();
        }
        /// <summary>
        /// Llama al to string, es virtual para ser sobreescrita en sus clases derivadas
        /// </summary>
        /// <returns>Devuelve la cadena de texto</returns>
        public virtual string Mostrar()
        {
            return this.ToString();
        }
        /// <summary>
        /// Un dispositivo sera igual a otro si su nombre y su precio son iguales
        /// </summary>
        /// <param name="d1">dispositivo 1 a ser comparado</param>
        /// <param name="d2">dispositivo 2 a ser comparado</param>
        /// <returns>retorna true si son iguales, false en caso contrario</returns>
        public static bool operator ==(Dispositivos d1, Dispositivos d2)
        {
            if (d1.Nombre == d2.Nombre && d1.precio == d2.precio)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si 2 dispositivos son distintos
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>retorna true si son distintos, false caso contrario</returns>
        public static bool operator !=(Dispositivos d1, Dispositivos d2)
        {
            return !(d1 == d2);
        }
        #endregion
    }
}
