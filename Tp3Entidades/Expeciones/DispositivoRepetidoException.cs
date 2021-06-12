using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expeciones
{
    public class DispositivoRepetidoException : Exception
    {
        public DispositivoRepetidoException() : base("Dispositivo repetido")
        {

        }

        public DispositivoRepetidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
