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
    public partial class reporteUsuariosTodos : Form
    {
        //Se instancian clases
        menuPrincipal mp = new menuPrincipal();
        modeloReportes mr = new modeloReportes();

        public reporteUsuariosTodos()
        {
            InitializeComponent();
            mr.reportaGridUsuariosTodos();
            mr.cargaGridUsuarios(dataGridView1);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
