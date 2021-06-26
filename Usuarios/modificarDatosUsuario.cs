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
    public partial class modificarDatosUsuario : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        modeloNiveles mn = new modeloNiveles();
        modeloBitacora mb = new modeloBitacora();
        validaciones va = new validaciones();

        public modificarDatosUsuario()
        {
            InitializeComponent();
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            mu.cargarComboLogin(comboBoxLogin);
            mn.cargarComboNiveles(comboBoxNivel);
            mu.cargarComboCondicion(comboBoxCondicion);
            uti.bloquear4(true, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
        }

        private void ModificarDatosUsuario_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(campoPassword.Text != "" || campoId.Text != "" || campoNombre.Text != "" || campoApellido.Text != "" || comboBoxNivel.Text != ""
            || comboBoxCondicion.Text != "" || campoFecha.Text != "")
            {
                mn.mostrarCodigo(comboBoxNivel.Text, campoPrueba2);
                if (mu.modificarDatosUsuario(comboBoxLogin.Text, campoId.Text, campoNombre.Text, campoApellido.Text,campoPassword.Text, 
                campoPrueba2.Text,comboBoxLogin.Text) == true)
                {
                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación Datos Usuarios", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificación Datos Usuario";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    MessageBox.Show("Los datos del usuario " + comboBoxLogin.Text + " han sido modificados correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar12(comboBoxLogin, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
                    uti.bloquear4(true, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
                    btnGuardar.Enabled = false;
                    comboBoxLogin.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Los datos del usuario: " + comboBoxLogin.Text + " no han sido modificados", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uti.bloquear4(true, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
                btnGuardar.Enabled = false;
                comboBoxLogin.Enabled = true;
            }

        }
        private void ComboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            mu.consultarUsuario2(comboBoxLogin.Text, campoPassword, campoId, campoNombre, campoApellido, campoPrueba, comboBoxCondicion, campoFecha);
            mn.mostrarNombre(campoPrueba.Text, comboBoxNivel);
            btnEditar.Enabled = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            uti.bloquear4(false, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
            campoFecha.Enabled = false;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            comboBoxLogin.Enabled = false;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar12(comboBoxLogin, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
            uti.bloquear4(true, campoPassword, campoId, campoNombre, campoApellido, comboBoxNivel, comboBoxCondicion, campoFecha);
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            comboBoxLogin.Enabled = true;
        }

        private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CampoId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CampoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
        }

        private void CampoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
