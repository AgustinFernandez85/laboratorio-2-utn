using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;
        /// <summary>
        /// Valida que sea un numero y lo setea en el atributo de la clase
        /// </summary>
        public string SetNumero { set { numero = validarNumero(value); } }

        /// <summary>
        /// Constructor que asigna por defecto un 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que asigna lo que se pase por parametro
        /// </summary>
        /// <param name="numero">variable de tipo double, numero a setear</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// valida que sea un numero y lo asigna
        /// </summary>
        /// <param name="strNumero"> numero en formato string </param>
        public Numero(string strNumero)
        {
            this.numero = validarNumero(strNumero);
        }

        /// <summary>
        /// Valida que lo que se pase por parametro sea un numero y lo devuelve en tipo double
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        /// <returns> devuelve el numero validado o un 0 en caso de error </returns>
        double validarNumero(string strNumero)
        {
            double auxNumero;

            if (!(double.TryParse(strNumero, out auxNumero)))
                auxNumero = 0;

            return auxNumero;
        }
        /// <summary>
        /// Suma entre 2 objetos de tipo Numero
        /// </summary>
        /// <param name="numero1">Objeto nro1 tipo Numero</param>
        /// <param name="numero2">Objeto nro2 tipo Numero</param>
        /// <returns> retorna la suma entre el atributo numero de ambos objetos </returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        /// <summary>
        /// resta entre 2 objetos de tipo Numero
        /// </summary>
        /// <param name="numero1">Objeto nro1 tipo Numero</param>
        /// <param name="numero2">Objeto nro2 tipo Numero</param>
        /// <returns> retorna la resta entre el atributo numero de ambos objetos </returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }
        /// <summary>
        /// multiplicacion entre 2 objetos de tipo Numero
        /// </summary>
        /// <param name="numero1">Objeto nro1 tipo Numero</param>
        /// <param name="numero2">Objeto nro2 tipo Numero</param>
        /// <returns> retorna la multiplicacion entre el atributo numero de ambos objetos </returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }
        /// <summary>
        /// division entre 2 objetos de tipo Numero y si es 0 devuelve el valor minimo de un double
        /// </summary>
        /// <param name="numero1">Objeto nro1 tipo Numero</param>
        /// <param name="numero2">Objeto nro2 tipo Numero</param>
        /// <returns> retorna la division entre el atributo numero de ambos objetos o el double.minValue en caso de que el dividendo sea 0</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            if (numero2.numero == 0)
                return double.MinValue;
            else
                return numero1.numero / numero2.numero;

        }

        /// <summary>
        /// Pasa un numero de binario a decimal
        /// </summary>
        /// <param name="binario">variable de tipo string que contiene la cadena de numeros decimales</param>
        /// <returns> retorna un string convertido a binario </returns>
        public static string BinarioDecimal(string binario)
        {
            string numeroBinario = "Valor invalido";
            if (esBinario(binario)) 
            {
                numeroBinario = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroBinario;
        }

        /// <summary>
        /// Parsea de decimal a binario
        /// </summary>
        /// <param name="numero"> variable tipo double que contiene el numero a parsear</param>
        /// <returns> retorna un string con el numero en binario o valor invalido en caso de no poder</returns>
        public static string DecimalBinario(double numero)
        {
            string resultado = "";
            int numeroInt = (int)numero;

            if (numeroInt > 0)
            {
                while (numeroInt > 0)
                {
                    if (numeroInt % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }

                    numeroInt = numeroInt / 2;
                }
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }
        /// <summary>
        /// Pasa de decimal a binario
        /// </summary>
        /// <param name="numero"> numero a parsear en tipo string</param>
        /// <returns> retorna el nuimero en binario si puede o valor invalido en caso contrario </returns>
        public static string DecimalBinario(string numero)
        {
            string resultado;
            double numeroDouble;

            if (double.TryParse(numero, out numeroDouble))
            {
                resultado = DecimalBinario(numeroDouble);
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }
        /// <summary>
        /// Valida si un numero es binario
        /// </summary>
        /// <param name="binario">string que contiene el numero a validar</param>
        /// <returns> retorna true si el numero es binario y false en caso contrario </returns>
        static bool esBinario(string binario)
        {
            bool retorno = true;
            char[] arrayBinario = binario.ToCharArray();

            for (int i = 0; i < arrayBinario.Length; i++)
            {
                if (arrayBinario[i] != '0' && arrayBinario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
    }
}
