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
    public partial class anularTransaccion : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloDetalles md = new modeloDetalles();
        modeloTransacciones mt = new modeloTransacciones();
        modeloBitacora mb = new modeloBitacora();

        public anularTransaccion()
        {
            InitializeComponent();
            btnAnular.Enabled = false;
            mt.cargarComboTransacciones(comboBoxNumTransaccion);
            uti.bloquear1(true, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            btnAnular.Enabled = false;
            uti.limpiar4(comboBoxNumTransaccion, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void ComboBoxNumTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBoxNumTransaccion.Text == ""))
            {
                btnAnular.Enabled = true;
                mt.consultarTransaccion(comboBoxNumTransaccion.Text, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
                mcu.mostrarSaldoCuenta(campoNumCuenta.Text, campoSaldoViejo);
                mcu.mostrarMontoCuenta(campoNumCuenta.Text, campoLimite);
                mcu.mostrarCondicionCuenta2(campoNumCuenta.Text, campoCondicion);
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxNumTransaccion.Focus();
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            int iResultado;
            String num = comboBoxNumTransaccion.Text;
            double monto = Convert.ToDouble(campoMonto.Text);
            if (campoCondicion.Text.Contains("Activa"))
            {
                if (comboBoxNumTransaccion.Text != "")
                {
                    if (MessageBox.Show("¿Desea anular la transacción #" + num + "?", "Anular transacción", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("La tarnsacción #" + num + " ha sido anulada correctamente", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        mt.ingresarTransaccionAnulada(this.campoNumCuenta.Text, Convert.ToDateTime(campoFecha.Text), this.campoTipo.Text,
                        campoMonto.Text, campoResponsable.Text, campoDetalle.Text, comboBoxNumTransaccion.Text);

                        //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                        mt.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value = this.campoNumCuenta.Text;
                        mt.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                        mt.oDataAdapter.InsertCommand.Parameters["@tipo"].Value = this.campoTipo.Text;
                        mt.oDataAdapter.InsertCommand.Parameters["@monto"].Value = monto;
                        mt.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoResponsable.Text;
                        mt.oDataAdapter.InsertCommand.Parameters["@detalle"].Value = this.campoDetalle.Text;
                        mt.oDataAdapter.InsertCommand.Parameters["@numTransaccion"].Value = this.comboBoxNumTransaccion.Text;
                        mt.oConexion.Open(); //Abre la conexión con la BD
                        iResultado = mt.oDataAdapter.InsertCommand.ExecuteNonQuery();
                        //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                        mt.oConexion.Close(); //Cierra la conexión con la BD

                        //Bitácora
                        DateTime fecha = DateTime.Now;
                        mb.ingresarBitacora(Convert.ToDateTime(fecha), "Anulación Transacción", mp.campoLogin.Text);
                        //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                        mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                        mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Anulación Transacción";
                        mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                        mb.oConexion.Open(); //Abre la conexión con la BD
                        iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                        //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                        mb.oConexion.Close(); //Cierra la conexión con la BD

                        if (campoTipo.Text.Contains("Credito"))
                        {
                            mcu.actualizarSaldoResta(campoNumCuenta.Text, Convert.ToDouble(campoSaldoViejo.Text), monto);
                            mcu.actualizarMontoSuma(campoNumCuenta.Text, Convert.ToDouble(campoLimite.Text), monto);
                            mt.anularTransaccion(num);
                        }
                        else
                        {
                            mcu.actualizarSaldoSuma(campoNumCuenta.Text, Convert.ToDouble(campoSaldoViejo.Text), monto);
                            mcu.actualizarMontoResta(campoNumCuenta.Text, Convert.ToDouble(campoLimite.Text), monto);
                            mt.anularTransaccion(num);
                        }

                        md.eliminarDetalle(this.comboBoxNumTransaccion.Text);//Elimina los detalles de compra de la transacción anulada
                        comboBoxNumTransaccion.Items.Clear();
                        mt.cargarComboTransacciones(comboBoxNumTransaccion);
                        uti.bloquear1(true, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
                        uti.limpiar4(comboBoxNumTransaccion, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
                        btnAnular.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("La transacción #" + num + " no pudo ser anulada", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        uti.bloquear1(true, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
                        uti.limpiar4(comboBoxNumTransaccion, campoNumCuenta, campoTipo, campoMonto, campoResponsable, campoDetalle, campoFecha);
                        btnAnular.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Imposible anular la transacción, la cuenta está inactiva", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
