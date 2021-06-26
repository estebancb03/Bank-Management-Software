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
    public partial class modificarMontoLimiteCredito : Form
    {
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloBitacora mb = new modeloBitacora();

        public static double mlcViejo = 0;
        public static double mlcNuevo = 0;
        public static double mdViejo = 0;
        public static double mdNuevo = 0;

        public modificarMontoLimiteCredito()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            campoMontoLimite.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcu.mostrarMontoLimite(comboBoxNumCuenta.Text, campoMontoLimite);
            mcu.mostrarMontoCuenta2(comboBoxNumCuenta.Text,campoPrueba);
            mlcViejo = Convert.ToDouble(campoMontoLimite.Text);
            mdViejo = Convert.ToDouble(campoPrueba.Text);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            comboBoxNumCuenta.Enabled = false;
            campoMontoLimite.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(comboBoxNumCuenta.Text == "" || campoMontoLimite.Text == ""))
            {
                String numCuenta = this.comboBoxNumCuenta.Text;
                String montoLimite = this.campoMontoLimite.Text;
                mlcNuevo = Convert.ToDouble(montoLimite);
                Double diferencia = 0;

                if (mlcViejo > mlcNuevo)
                {
                    diferencia = mlcViejo - mlcNuevo;
                    mdNuevo = mdViejo - diferencia;
                }
                if (mlcViejo < mlcNuevo)
                {
                    diferencia = mlcNuevo - mlcViejo;
                    mdNuevo = mdViejo + diferencia;
                } 
                if (mlcViejo == mlcNuevo) mdNuevo = mdViejo;

                if (mcu.modificarMontoLimite(numCuenta, montoLimite) == true)
                {
                    mcu.modificarMontoDisponible(numCuenta, (mdNuevo).ToString());
                    MessageBox.Show("El monto límite de crédito de la cuenta #" + numCuenta + "ha sido modificada " +
                    "correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar6(comboBoxNumCuenta, campoMontoLimite);
                    campoMontoLimite.Enabled = false;
                    comboBoxNumCuenta.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;

                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación MLC Cuenta", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificación MLC Cuenta";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                }
                else
                {
                    MessageBox.Show("El monto límite de crédito de la cuenta #" + numCuenta + "no ha sido modificada",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar6(comboBoxNumCuenta, campoMontoLimite);
            campoMontoLimite.Enabled = false;
            comboBoxNumCuenta.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }
    }
}
