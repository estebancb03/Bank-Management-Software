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
    public partial class reporteUsuariosNivel : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloNiveles mn = new modeloNiveles();
        modeloReportes mr = new modeloReportes();

        public reporteUsuariosNivel()
        {
            InitializeComponent();
            mn.cargarComboNiveles(comboBoxNivel);
        }

        private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarCodigo(comboBoxNivel.Text, campoPrueba);
            mr.reportaGridUsuariosNivel(campoPrueba.Text);
            mr.cargaGridTransacciones(dataGridView1);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
