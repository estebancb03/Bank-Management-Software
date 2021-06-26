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
    public partial class registrarCliente : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        modeloClientes mc = new modeloClientes();
        validaciones va = new validaciones();
        inicioSesion ise = new inicioSesion();
        modeloBitacora mb = new modeloBitacora();

        DateTime fecha = DateTime.Now;

        public registrarCliente()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado;
            String numCliente = campoId.Text;
            if (campoId.Text == "" || campoNombre.Text == "" || campoTelefono.Text == "" || campoDireccion.Text == ""
            || campoCorreo.Text == "" || campoFecha.Text == "")
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                campoId.Focus();
            }
            else
            {
                if (mc.buscarId(campoId.Text) == true)
                {
                    MessageBox.Show("El cliente # " + campoId.Text + " ya existe, intente con otra identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    campoId.Focus();
                }
                else
                {
                    mc.ingresarCliente(this.campoId.Text, this.campoNombre.Text, this.campoTelefono.Text, this.campoDireccion.Text,
                    this.campoCorreo.Text, Convert.ToDateTime(campoFecha.Text));

                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mc.oDataAdapter.InsertCommand.Parameters["@identificacion"].Value = this.campoId.Text;
                    mc.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                    mc.oDataAdapter.InsertCommand.Parameters["@telefono"].Value = this.campoTelefono.Text;
                    mc.oDataAdapter.InsertCommand.Parameters["@direccion"].Value = this.campoDireccion.Text;
                    mc.oDataAdapter.InsertCommand.Parameters["@correo"].Value = this.campoCorreo.Text;
                    mc.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);

                    mc.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mc.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mc.oConexion.Close(); //Cierra la conexión con la BD

                    //Bitácora
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Cliente", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Cliente";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    MessageBox.Show("Cliente #" + numCliente + " ha sido registrado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar1(campoId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar1(campoId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
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

        private void CampoTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CampoCorreo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CampoCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
