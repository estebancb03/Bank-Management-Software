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
    public partial class reporteRolesTodos : Form
    {
        //Se instancian clases
        modeloReportes mr = new modeloReportes();
        

        public reporteRolesTodos()
        {
            InitializeComponent();
            mr.reportaGridRolesTodos();
            mr.cargaGridRoles(dataGridView1);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
