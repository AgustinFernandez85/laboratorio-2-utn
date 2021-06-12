using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Expeciones;
using Entidades;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cambio el titulo de la consola
            Console.Title = "Agustin-Fernandez-2C";
            
            //Creo la fabrica
            Fabrica fabrica = new Fabrica();

            //Harcodeo los dispositivos
            Dispositivos d1 = new Notebook("Notebook hp", 25,500,Notebook.EModeloNotebook.HP);
            Notebook d2 = new Notebook("Notebook MAC", 1,242424,Notebook.EModeloNotebook.Mac);
            Dispositivos d3 = new Celular("Huawei mate 10",64,15000,Celular.EModeloCelulares.Huawei);
            Celular d4 = new Celular("Samsung Note 10",32,40000,Celular.EModeloCelulares.Samsung);

            //Tratamos de cargar los dispositivos
            try
            {
                if (fabrica + d1)
                {
                    Console.WriteLine("Se cargo con exito el dispositivo 1");
                }
                if (fabrica + d2)
                {
                    Console.WriteLine("Se cargo con exito el dispositivo 2");
                }
                if (fabrica + d3)
                {
                    Console.WriteLine("Se cargo con exito el dispositivo 3");
                }
                if (fabrica + d4)
                {
                    Console.WriteLine("Se cargo con exito el dispositivo 4");
                }
                //Cargo un dispositivo repetido
                Console.WriteLine("Ahora se trata de cargar un dispositivo repetido deberia tirar excepcion");
                if (fabrica + d1)
                {
                    Console.WriteLine("Se cargo con exito el dispositivo 1");
                }
            }
            catch (DispositivoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("Se trata de sacar un dispositivo de la lista con el operador -");
                if (fabrica - d1)
                {
                    Console.WriteLine("Dispositivo quitado con exito");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("Se muestran los productos harcodeados y se crea el archivo .xml");
                Console.WriteLine();
                Console.WriteLine(fabrica.ToString());

                Fabrica.Guardar(fabrica);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();

            try
            {
                Console.WriteLine("Se guarda el archivo en .txt");
                string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Fabrica.txt");
                ArchivoTxt txt = new ArchivoTxt();
                txt.Guardar(path,fabrica.ToString());
                Console.WriteLine("Datos guardados con exito");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
