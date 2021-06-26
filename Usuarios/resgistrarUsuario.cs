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
    public partial class resgistrarUsuario : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        validaciones va = new validaciones();
        modeloNiveles mn = new modeloNiveles();
        modeloBitacora mb = new modeloBitacora();
        public resgistrarUsuario()
        {
            InitializeComponent();
            mn.cargarComboNiveles(comboBoxNivel);
            mu.cargarComboCondicion(comboBoxCondicion);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar10(campoId, campoNombre, campoApellido, campoLogin, campoPassword, comboBoxNivel, comboBoxCondicion, campoFecha);
        }
     
        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if(campoId.Text == "" || campoNombre.Text == "" || campoApellido.Text == "" || campoLogin.Text == "" || campoPassword.Text == ""
            || comboBoxNivel.Text == "" || comboBoxCondicion.Text == "" || campoFecha.Text == "")
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                campoId.Focus();
            }
            else
            {
                if(mu.buscarLogin(campoLogin.Text) == true)
                {
                    MessageBox.Show("El usuario "+campoLogin.Text+" ya existe, intente con otro nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    campoLogin.Focus();
                }
                else
                {
                    mu.ingresarUsuario(campoId.Text, campoNombre.Text, campoApellido.Text, Convert.ToDateTime(campoFecha.Text), campoLogin.Text,
                    campoPassword.Text, comboBoxNivel.Text, comboBoxCondicion.Text);

                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mu.oDataAdapter.InsertCommand.Parameters["@id"].Value = this.campoId.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@apellido"].Value = this.campoApellido.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                    mu.oDataAdapter.InsertCommand.Parameters["@login"].Value = this.campoLogin.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@password"].Value = this.campoPassword.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@codNivel"].Value = this.campoPrueba.Text;
                    mu.oDataAdapter.InsertCommand.Parameters["@condicion"].Value = this.comboBoxCondicion.Text;

                    mu.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mu.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mu.oConexion.Close(); //Cierra la conexión con la BD

                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Usuario", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Usuario";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    MessageBox.Show("Usuario: " + campoLogin.Text + ", ha sido registrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar10(campoId, campoNombre, campoApellido, campoLogin, campoPassword, comboBoxNivel, comboBoxCondicion, campoFecha);
                }
            }
        }

        private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarCodigo(comboBoxNivel.Text, campoPrueba);
        }
    }
}
