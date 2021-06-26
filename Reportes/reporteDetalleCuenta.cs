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
    public partial class reporteDetalleCuenta : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloReportes mr = new modeloReportes();
        public reporteDetalleCuenta()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            mr.reportaGridDetallesCuenta(comboBoxNumCuenta.Text);
            mr.cargaGridDetalles(dataGridView1);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
