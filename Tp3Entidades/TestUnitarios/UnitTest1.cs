using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using Expeciones;
using Archivos;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea que se lanze la expecion dispositivo repetido al agregar 2 veces el mismo dispositivo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DispositivoRepetidoException))]
        public void TestProductoRepetidoException()
        {
            bool retorno;
            Notebook dispo = new Notebook("PcGamer", 50, 5000, Notebook.EModeloNotebook.HP);
            Fabrica fabrica = new Fabrica();

            retorno = fabrica + dispo;
            retorno = fabrica + dispo;
        }
        /// <summary>
        /// Verifico que la lista de la fabrica no sea null y este instanciada
        /// </summary>
        [TestMethod]
        public void TestVerificarListaNula() 
        {
            Fabrica fabrica = new Fabrica();
            Assert.IsNotNull(fabrica.ListaDispositivos);
        }
    }
}
