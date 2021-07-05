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

        [TestMethod]
        //Voy a probar que lo quie escribo sea lo mismo que voy a leer despues en xml
        public void ProbarLecturaYEscrituraArchivos() 
        {
            //Creo la fabrica y el celular a agregar
            Fabrica fabricaAux = new Fabrica();
            Fabrica fabricaAux2 = new Fabrica();
            Celular celular = new Celular("Huawei mate 10",50,4000,Celular.EModeloCelulares.Huawei);

            //Agrego el celular a la lista de la fabrica
            fabricaAux.ListaDispositivos.Add(celular);

            //Escribo la fabrica en un archivo xml, esto deberia tener al celular
            Xml<Fabrica> xmlFabrica = new Xml<Fabrica>();
            string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Fabrica.xml");
            xmlFabrica.Guardar(path, fabricaAux);

            xmlFabrica.Leer(path, out fabricaAux2);

            Assert.IsTrue(fabricaAux == fabricaAux2);
        }
    }
}
