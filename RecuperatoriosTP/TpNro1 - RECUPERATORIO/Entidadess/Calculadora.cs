using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador y hace la cuenta entre ambos numeros
        /// </summary>
        /// <param name="num1">variable de tipo Numero para hacer el calculo</param>
        /// <param name="num2">variable de tipo Numero para hacer el calculo</param>
        /// <param name="operador">variable de tipo String que contiene el operando de la cuenta</param>
        /// <returns> retorna el resultado de la cuenta realizada </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string auxOperador;
            double resultado = 0;
            auxOperador = validarOperador(Convert.ToChar(operador));
            switch (auxOperador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea +,-,/,* y si no es ninguno le asina por defecto el +
        /// </summary>
        /// <param name="operador">variable de tipo char que contiene el operador</param>
        /// <returns> retorna el operador en formato string ya validado </returns>
        static string validarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                retorno = Convert.ToString(operador);
            }

            return retorno;
        }
    }
}
