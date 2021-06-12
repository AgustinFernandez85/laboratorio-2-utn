using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace FrmPrincipal
{
    public partial class AgregarProducto : Form
    {
        Fabrica fabrica;
        /// <summary>
        /// El constructor recibe una fabrica para poder modificarla al agregar dispositivos a su lista
        /// </summary>
        /// <param name="fabrica"></param>
        public AgregarProducto(Fabrica fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }
        /// <summary>
        /// En el load cargo por defecto los tipos notebook en el combo box y lo inhabilito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            this.comboBoxModelo.DataSource = Enum.GetValues(typeof(Notebook.EModeloNotebook));
            this.comboBoxModelo.Enabled = false;
        }
        /// <summary>
        /// En este evento hago la logica para que dependiendo de que tipo haya elegido le carguen los modelos del enumerado para sus respectivos dispositivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxTipo.Text == "Notebook")
            {
                this.comboBoxModelo.DataSource = Enum.GetValues(typeof(Notebook.EModeloNotebook));
                this.comboBoxModelo.Enabled = true;
            }
            else if(this.comboBoxTipo.Text == "Celular")
            {
                this.comboBoxModelo.DataSource = Enum.GetValues(typeof(Celular.EModeloCelulares));
                this.comboBoxModelo.Enabled = true;
            }
        }
        /// <summary>
        /// En el boton agregar esta la logica para validar que los datos sean enteros o flotantes en sus respectivos casos
        /// y validar que no haya campos en nulo. Despues de eso agregar un Dispositivo a la lista y cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //0 es notebook y 1 es celular
            int cantidad;
            float precio;
            if (this.txtNombre.Text != String.Empty)
            {
                int.TryParse(this.txtCantidad.Text, out cantidad);
                float.TryParse(this.txtPrecio.Text, out precio);

                if (this.comboBoxTipo.SelectedItem != null && this.comboBoxModelo.SelectedItem != null)
                {
                    if (this.comboBoxTipo.SelectedIndex == 0)
                    {
                        if (this.fabrica + new Notebook(this.txtNombre.Text, cantidad, precio, (Notebook.EModeloNotebook)this.comboBoxModelo.SelectedItem))
                        {
                            MessageBox.Show("Se agrego con exito la notebook");
                            this.Close();
                        }
                    }
                    else if (this.comboBoxTipo.SelectedIndex == 1)
                    {

                        if (this.fabrica + new Celular(this.txtNombre.Text, cantidad, precio, (Celular.EModeloCelulares)this.comboBoxModelo.SelectedItem))
                        {
                            MessageBox.Show("Se agrego con exito el celular");
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe agregar un nombre!");
            }
        }
    }
}
