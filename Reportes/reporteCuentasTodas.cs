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
    public partial class reporteCuentasTodas : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloReportes mr = new modeloReportes();

        public reporteCuentasTodas()
        {
            InitializeComponent();
            mr.reportaGridCuentasTodas();
            mr.cargaGridCuentas(dataGridView1);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
