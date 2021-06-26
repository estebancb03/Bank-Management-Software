using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creditos
{
    public partial class reporteRolesNivel : Form
    {
        //Se instancian clases
        modeloReportes mr = new modeloReportes();
        modeloNiveles mn = new modeloNiveles();

        public reporteRolesNivel()
        {
            InitializeComponent();
            mn.cargarComboNiveles(comboBoxNivel);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarCodigo(comboBoxNivel.Text, campoPrueba);
            mr.reportaGridRolesNivel(campoPrueba.Text);
            mr.cargaGridRoles(dataGridView1);
        }

        private void BtnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
