using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expeciones;
using Entidades;
using Archivos;

namespace FrmPrincipal
{
    public partial class FormPrincipal : Form
    {
        Fabrica fabrica = new Fabrica();
        public FormPrincipal()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creo un archivo de texto llamado Fabrica.txt con sus atributos y propiedades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_txt_Click(object sender, EventArgs e)
        {
            ArchivoTxt texto = new ArchivoTxt();
            string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Fabrica.txt");
            try
            {
                if (texto.Guardar(path, fabrica.ToString()))
                {
                    MessageBox.Show("Se ha guardado el archivo con exito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Hardcodeo algunos dispositivos probando la funcionabilidad de los operadores y la excepcion creada por mi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
           // Dispositivos dispo = new Notebook("PcGamer",50,5000,Notebook.EModeloNotebook.HP);
           // Dispositivos dispo2 = new Celular("Huawei mate",520,50300,Celular.EModeloCelulares.Huawei);

            //try
            //{
            //    if (this.fabrica + dispo2 && this.fabrica + dispo)
            //    {
            //        MessageBox.Show("Se han hardcodeado 2 productos con exito");
            //    }
            //}
            //catch (DispositivoRepetidoException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        /// <summary>
        /// Creo un archivo xml de fabrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xml_Click(object sender, EventArgs e)
        {
            try
            {
                Fabrica.Guardar(fabrica);
                MessageBox.Show("Archivo guardado con exito XML");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Llamo al form agregar para crear un dispositivo y agregarlo a la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            AgregarProducto formAgregar = new AgregarProducto(this.fabrica);
            formAgregar.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fabrica.CalcularStock());
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            QuitarDispositivo formQuitar = new QuitarDispositivo(fabrica);
            formQuitar.ShowDialog();
        }

        private void btn_LeerArchivoXml_Click(object sender, EventArgs e)
        {
            try
            {
                Xml<Fabrica> fabricaAux = new Xml<Fabrica>();
                string path = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Fabrica.xml");
                if (fabricaAux.Leer(path, out this.fabrica))
                {
                    MessageBox.Show("Se ha leido con exito y se han cargado los dispositivos al a fabrica");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
