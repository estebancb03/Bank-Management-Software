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
    public partial class modificarCondicionUsuario : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        modeloBitacora mb = new modeloBitacora();
        public modificarCondicionUsuario()
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            comboBoxCondicion.Enabled = false;
            mu.cargarComboLogin(comboBoxLogin);
            mu.cargarComboCondicion(comboBoxCondicion);
        }

        private void ComboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            mu.mostrarCondicionUsuario(comboBoxLogin.Text,comboBoxCondicion);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            comboBoxLogin.Enabled = false;
            comboBoxCondicion.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(comboBoxLogin.Text == "" || comboBoxCondicion.Text == ""))
            {
                String login = this.comboBoxLogin.Text;
                String condicion = this.comboBoxCondicion.Text;
                if (mu.modificarCondicion(login, condicion) == true)
                {
                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación Condición Usuario", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificación Condición Usuario";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                    MessageBox.Show("La condición del usuario: " + login + ", ha sido modificada correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar5(comboBoxLogin, comboBoxCondicion);
                    comboBoxCondicion.Enabled = false;
                    comboBoxLogin.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("La condición del usuario: " + login + ", no ha sido modificada", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar5(comboBoxLogin, comboBoxCondicion);
            comboBoxCondicion.Enabled = false;
            comboBoxLogin.Enabled = true;
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
