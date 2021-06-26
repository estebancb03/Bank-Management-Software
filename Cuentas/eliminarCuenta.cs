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
    public partial class eliminarCuenta : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloTransacciones mt = new modeloTransacciones();
        modeloBitacora mb = new modeloBitacora();

        public eliminarCuenta()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            uti.bloquear1(true, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBoxNumCuenta.Text == ""))
            {
                String num = comboBoxNumCuenta.Text;
                btnEliminar.Enabled = true;
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
            btnEliminar.Enabled = false;
            uti.limpiar4(comboBoxNumCuenta, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
            comboBoxNumCuenta.Focus();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            String num = comboBoxNumCuenta.Text;
            if (campoCondicion.Text.Contains("Activa"))
            {
                if (Convert.ToDouble(campoSaldoPrueba.Text) == 0)
                {
                    if (MessageBox.Show("¿Desea eliminar la cuenta #" + num + "?", "Eliminar cuenta", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("La cuenta #" + num + " ha sido eliminada correctamente", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        mcu.eliminarCuenta(comboBoxNumCuenta.Text); //Elimina la cuenta
                        mt.anularTransaccion2(comboBoxNumCuenta.Text); //Elimina todas las transacciones de la cuenta
                        btnEliminar.Enabled = false;
                        comboBoxNumCuenta.Items.Clear();
                        mcu.cargarComboCuentas(comboBoxNumCuenta);
                        uti.bloquear1(true, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                        uti.limpiar4(comboBoxNumCuenta, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                        comboBoxNumCuenta.Focus();

                        //Bitácora
                        DateTime fecha = DateTime.Now;
                        int iResultado = 0;
                        mb.ingresarBitacora(Convert.ToDateTime(fecha), "Eliminación Cuenta", mp.campoLogin.Text);
                        //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                        mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                        mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Eliminación Cuenta";
                        mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                        mb.oConexion.Open(); //Abre la conexión con la BD
                        iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                        //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                        mb.oConexion.Close(); //Cierra la conexión con la BD
                    }
                }
                else
                {
                    MessageBox.Show("Imposible eliminar la cuenta, existen créditos pendientes de pago", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    btnEliminar.Enabled = false;
                    uti.bloquear1(true, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                    uti.limpiar4(comboBoxNumCuenta, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                    comboBoxNumCuenta.Focus();
                }
            }
            else
            {
                MessageBox.Show("Imposible eliminar la cuenta, la cuenta está inactiva", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                btnEliminar.Enabled = false;
                uti.bloquear1(true, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                uti.limpiar4(comboBoxNumCuenta, campoId, campoCondicion, campoSaldo, campoLimite, campoMonto, campoFecha);
                comboBoxNumCuenta.Focus();
            }
        }
    }
}
