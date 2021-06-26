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
    public partial class registrarTransaccion : Form
    {
        //Se inicializan clases
        utilidades uti = new utilidades();
        validaciones va = new validaciones();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloTransacciones mt = new modeloTransacciones();
        public registrarTransaccion()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            mt.cargarComboTipo(comboBoxTipo);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado;
            String numTransaccion = campoNumTransaccion.Text;
            if (campoNumTransaccion.Text == "" || comboBoxNumCuenta.Text == "" || comboBoxTipo.Text == "" || 
            campoMonto.Text == "" || campoNombre.Text == "" || campoFecha.Text == "")
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxNumCuenta.Focus();
            }
            else
            {
                mt.ingresarTransaccion(this.comboBoxNumCuenta.Text, Convert.ToDateTime(campoFecha.Text), comboBoxTipo.Text, 
                campoMonto.Text, campoNombre.Text, campoDetalle.Text, campoNumTransaccion.Text);

                //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                mt.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value = this.comboBoxNumCuenta.Text;
                mt.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                mt.oDataAdapter.InsertCommand.Parameters["@tipo"].Value = this.comboBoxTipo.Text;
                mt.oDataAdapter.InsertCommand.Parameters["@monto"].Value = this.campoMonto.Text;
                mt.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                mt.oDataAdapter.InsertCommand.Parameters["@detalle"].Value = this.campoDetalle.Text;
                mt.oDataAdapter.InsertCommand.Parameters["@numTransaccion"].Value = this.campoNumTransaccion.Text;

                mt.oConexion.Open(); //Abre la conexión con la BD
                iResultado = mt.oDataAdapter.InsertCommand.ExecuteNonQuery();
                //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                mt.oConexion.Close(); //Cierra la conexión con la BD
                /*mcu.actualizarSaldo(comboBoxNumCuenta.Text,comboBoxTipo.Text,Convert.ToInt32(mcu.averiguarSaldoCuenta
                (comboBoxNumCuenta.Text)), Convert.ToInt32(campoMonto.Text));*/
                MessageBox.Show("Transaccion #" + numTransaccion + " registrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uti.limpiar7(campoNumTransaccion, comboBoxNumCuenta, comboBoxTipo, campoMonto, campoNombre, campoDetalle, campoFecha);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar7(campoNumTransaccion, comboBoxNumCuenta, comboBoxTipo, campoMonto, campoNombre, campoDetalle, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void CampoFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
