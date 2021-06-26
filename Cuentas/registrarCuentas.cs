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
    public partial class registrarCuentas : Form
    {
        //Se incializan clases
        utilidades uti = new utilidades();
        validaciones va = new validaciones();
        modeloClientes mc = new modeloClientes();
        modeloCuentas mcu = new modeloCuentas();
        menuPrincipal mp = new menuPrincipal();
        modeloBitacora mb = new modeloBitacora();

        public registrarCuentas()
        {
            InitializeComponent();
            mc.cargarComboId(comboBoxId);
            mcu.cargarComboCondicion(comboBoxCondicion);
            campoSaldo.Text = "0";
            campoSaldo.Enabled = false;
            campoMonto.Enabled = false;
        }

        private void RegistrarCuentas_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado;
            String numCuenta = campoNumCuenta.Text;
            if (campoNumCuenta.Text == "" || comboBoxId.Text == "" || comboBoxCondicion.Text == "" || campoSaldo.Text == ""
            || campoLimite.Text == "" || campoMonto.Text == "")
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                campoNumCuenta.Focus();
            }
            else
            {
                if(mcu.buscarCuenta(campoNumCuenta.Text) == true)
                {
                    MessageBox.Show("La cuenta # " + campoNumCuenta.Text + " ya existe, intente con otra número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    campoNumCuenta.Focus();
                }
                else
                {
                    mcu.ingresarCuenta(this.campoNumCuenta.Text, Convert.ToDateTime(campoFecha.Text),
                    this.comboBoxCondicion.Text, this.campoSaldo.Text, this.campoLimite.Text, this.campoMonto.Text, this.comboBoxId.Text);

                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mcu.oDataAdapter.InsertCommand.Parameters["@num"].Value = this.campoNumCuenta.Text;
                    mcu.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                    mcu.oDataAdapter.InsertCommand.Parameters["@condicion"].Value = this.comboBoxCondicion.Text;
                    mcu.oDataAdapter.InsertCommand.Parameters["@saldo"].Value = this.campoSaldo.Text;
                    mcu.oDataAdapter.InsertCommand.Parameters["@montoLimite"].Value = this.campoLimite.Text;
                    mcu.oDataAdapter.InsertCommand.Parameters["@montoDisponible"].Value = this.campoMonto.Text;
                    mcu.oDataAdapter.InsertCommand.Parameters["@id"].Value = this.comboBoxId.Text;

                    mcu.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mcu.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mcu.oConexion.Close(); //Cierra la conexión con la BD

                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Cuenta", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Cuenta";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    MessageBox.Show("Cuenta #" + numCuenta + " registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar3(campoNumCuenta, comboBoxId, comboBoxCondicion, campoLimite, campoMonto, campoFecha);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar3(campoNumCuenta, comboBoxId, comboBoxCondicion, campoLimite, campoMonto, campoFecha);
        }

        private void CampoNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
            campoMonto.Text = campoLimite.Text;
        }

        private void CampoMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }
    }
}
