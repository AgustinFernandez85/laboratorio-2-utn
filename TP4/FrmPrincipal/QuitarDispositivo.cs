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
    public partial class QuitarDispositivo : Form
    {
        Fabrica fabricaAux;
        public QuitarDispositivo(Fabrica fabrica)
        {
            InitializeComponent();
            this.fabricaAux = fabrica;
        }

        private void QuitarDispositivo_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DispositivoDAO.LeerTodo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Dispositivos dispo = null;
            string nombre;
            if (MessageBox.Show("Esta seguro que desea eliminar el producto?", "Elimanando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();

                for (int i = 0; i < fabricaAux.ListaDispositivos.Count; i++)
                {
                    if (fabricaAux.ListaDispositivos[i].Nombre == nombre)
                    {
                        dispo = fabricaAux.ListaDispositivos[i];
                        break;
                    }
                }

                if (fabricaAux - dispo)
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = DispositivoDAO.LeerTodo();
                    MessageBox.Show("Dispositivo eliminado con exito");
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar");
                }
            }
        }
    }
}
