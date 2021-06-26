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
        modeloBitacora mb = new modeloBitacora();
        modeloTransacciones mt = new modeloTransacciones();
        public registrarTransaccion()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            campoNumTransaccion.Enabled = false;
            mt.mostrarNumeroTransaccion(campoPruebaNumero);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado;
            String numTransaccion = campoNumTransaccion.Text;
            if ((campoCondicion.Text).Contains("Activa"))
            {
                if (comboBoxNumCuenta.Text == "" || campoMonto.Text == "" || campoNombre.Text == "" || campoFecha.Text == "")
                {
                    MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxNumCuenta.Focus();
                }
                else
                {
                    double monto = Convert.ToDouble(campoMonto.Text);
                    if (mt.buscarCredito(comboBoxNumCuenta.Text, "Credito") == true)
                    {
                        if (monto > 0 && monto <= Convert.ToDouble(campoSaldoViejo.Text))
                        {
                            mt.ingresarTransaccion(this.comboBoxNumCuenta.Text, Convert.ToDateTime(campoFecha.Text), "Abono",
                            campoMonto.Text, campoNombre.Text, campoDetalle.Text, campoNumTransaccion.Text);

                            //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                            mt.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value = this.comboBoxNumCuenta.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                            mt.oDataAdapter.InsertCommand.Parameters["@tipo"].Value = "Abono";
                            mt.oDataAdapter.InsertCommand.Parameters["@monto"].Value = this.campoMonto.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@detalle"].Value = this.campoDetalle.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@numTransaccion"].Value = this.campoNumTransaccion.Text;
                            mt.oConexion.Open(); //Abre la conexión con la BD
                            iResultado = mt.oDataAdapter.InsertCommand.ExecuteNonQuery();
                            //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                            mt.oConexion.Close(); //Cierra la conexión con la BD

                            //Bitácora
                            DateTime fecha = DateTime.Now;
                            mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Abono", mp.campoLogin.Text);
                            //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                            mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                            mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Abono";
                            mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                            mb.oConexion.Open(); //Abre la conexión con la BD
                            iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                            //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                            mb.oConexion.Close(); //Cierra la conexión con la BD

                            mcu.actualizarSaldoResta(comboBoxNumCuenta.Text, Convert.ToDouble(campoSaldoViejo.Text), monto);
                            mcu.actualizarMontoSuma(comboBoxNumCuenta.Text, Convert.ToDouble(campoLimite.Text), monto);
                            MessageBox.Show("Transacción #" + campoNumTransaccion.Text + " registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            uti.limpiar7(campoNumTransaccion, comboBoxNumCuenta, campoMonto, campoNombre, campoDetalle, campoFecha);
                        }
                        else
                        {
                            MessageBox.Show("El monto del abono que desea hacer no es válido", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            campoMonto.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe un crédito al cual abonarle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uti.limpiar7(campoNumTransaccion, comboBoxNumCuenta, campoMonto, campoNombre, campoDetalle, campoFecha);
                    }
                }
            }
            else
            {
                MessageBox.Show("Imposible realizar la transacción, la cuenta está inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar7(campoNumTransaccion, comboBoxNumCuenta, campoMonto, campoNombre, campoDetalle, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void CampoFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcu.mostrarSaldoCuenta(comboBoxNumCuenta.Text, campoSaldoViejo);
            mcu.mostrarMontoCuenta(comboBoxNumCuenta.Text, campoLimite);
            mcu.mostrarCondicionCuenta2(comboBoxNumCuenta.Text, campoCondicion);
            campoNumTransaccion.Text = (Convert.ToDouble(campoPruebaNumero.Text) + 1).ToString();
        }

        private void CampoMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
        }
    }
}
