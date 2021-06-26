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
    public partial class modificarCondicionCuenta : Form
    {
        //Se inicializan clases
        utilidades uti = new utilidades();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloBitacora mb = new modeloBitacora();
        public modificarCondicionCuenta()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            mcu.cargarComboCondicion(comboBoxCondicion);
            comboBoxCondicion.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcu.mostrarCondicionCuenta(comboBoxNumCuenta.Text,comboBoxCondicion);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            comboBoxNumCuenta.Enabled = false;
            comboBoxCondicion.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(!(comboBoxNumCuenta.Text == "" || comboBoxCondicion.Text == ""))
            {
                String numCuenta = this.comboBoxNumCuenta.Text;
                String condicion = this.comboBoxCondicion.Text;
                if (mcu.modificarCondicion(numCuenta,condicion) == true)
                {
                    MessageBox.Show("La condición de la cuenta #"+numCuenta+"ha sido modificada correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar5(comboBoxNumCuenta, comboBoxCondicion);
                    comboBoxCondicion.Enabled = false;
                    comboBoxNumCuenta.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación Condición Cuenta", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificación Condición Cuenta";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                }
                else
                {
                    MessageBox.Show("La condición de la cuenta #"+numCuenta+"no ha sido modificada", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar5(comboBoxNumCuenta, comboBoxCondicion);
            comboBoxCondicion.Enabled = false;
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
