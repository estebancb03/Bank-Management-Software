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
    public partial class consultarCuentas : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        public consultarCuentas()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            uti.bloquear1(true,campoId,campoCondicion,campoSaldo,campoLimite,campoMonto,campoFecha);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void CampoId_TextChanged(object sender, EventArgs e)
        {

        }

        private void CampoMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void CampoLimite_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CampoSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (!(comboBoxNumCuenta.Text == ""))
            {
                String num = comboBoxNumCuenta.Text;
                mcu.consultarCuenta(comboBoxNumCuenta.Text, campoId, campoCondicion, campoSaldoPrueba, campoLimitePrueba, campoDisponiblePrueba, campoFecha);
                campoSaldo.Text = "₡" + campoSaldoPrueba.Text;
                campoLimite.Text = "₡" + campoLimitePrueba.Text;
                campoMonto.Text = "₡" + campoDisponiblePrueba.Text;
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxNumCuenta.Focus();
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar4(comboBoxNumCuenta, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
            comboBoxNumCuenta.Focus();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
