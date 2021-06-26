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
    public partial class reporteClientes : Form
    {
        //Se inicializan clases
        validaciones va = new validaciones();
        menuPrincipal mp = new menuPrincipal();
        modeloReportes mr = new modeloReportes();
        public reporteClientes()
        {
            InitializeComponent();
            campoNombre.Focus();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void CampoNombre_Enter(object sender, EventArgs e)
        {
            mr.reportaGridClientesNombre(campoNombre.Text);
            mr.cargaGridClientes(dataGridView1);
        }

        private void CampoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                mr.reportaGridClientesNombre(campoNombre.Text);
                mr.cargaGridClientes(dataGridView1);
            }
        }

        private void CampoNombre_Click(object sender, EventArgs e)
        {
            
        }
    }
}
