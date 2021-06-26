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
    public partial class consultarTransaccion : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloTransacciones mt = new modeloTransacciones();
        public consultarTransaccion()
        {
            InitializeComponent();
            mt.cargarComboTransacciones(comboBoxNumTransaccion);
            uti.bloquear1(true, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar4(comboBoxNumTransaccion, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!(comboBoxNumTransaccion.Text == ""))
            {
                mt.consultarTransaccion(comboBoxNumTransaccion.Text, campoNumCuenta, campoTipo, campoMontoPrueba, campoResponsable, campoDetalle, campoFecha);
                campoMonto.Text = "₡" + campoMontoPrueba.Text;
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxNumTransaccion.Focus();
            }
        }

        private void ComboBoxNumTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
