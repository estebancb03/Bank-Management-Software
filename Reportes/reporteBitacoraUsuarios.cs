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
    public partial class reporteBitacoraUsuarios : Form
    {
        //Se instancian clases
        modeloReportes mr = new modeloReportes();
        modeloUsuarios mu = new modeloUsuarios();

        public reporteBitacoraUsuarios()
        {
            InitializeComponent();
            mu.cargarComboLogin(comboBoxLogin);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            mr.reportaGridBitacoraUsuario(comboBoxLogin.Text);
            mr.cargaGridBitacora(dataGridView1);
        }
    }
}
