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
    public partial class modificarCliente : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        validaciones va = new validaciones();
        menuPrincipal mp = new menuPrincipal();
        modeloClientes mc = new modeloClientes();
        modeloBitacora mb = new modeloBitacora();

        public modificarCliente()
        {
            InitializeComponent(); 
            mc.cargarComboId(comboBoxId);
            uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(campoNombre.Text == "" || campoTelefono.Text == "" || campoDireccion.Text == ""
            || campoCorreo.Text == ""))
            {
                String id = comboBoxId.Text;
                if (mc.modificarCliente(id, this.campoNombre.Text, this.campoTelefono.Text, this.campoDireccion.Text,
                this.campoCorreo.Text) == true)
                {
                    MessageBox.Show("Los datos del cliente #"+id+" han sido modificados correctamente", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    btnGuardar.Enabled = false;
                    comboBoxId.Enabled = true;

                    //Bitácora
                    int iResultado = 0;
                    DateTime fecha = DateTime.Now;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación Cliente", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificacion Cliente";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                }
                else
                {
                    MessageBox.Show("Los datos del cliente #" + id + " no han sido modificados", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            uti.bloquear2(false, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            campoFecha.Enabled = false;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            comboBoxId.Enabled = false;
        }

        private void ComboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = comboBoxId.Text;
            mc.consultarCliente(id, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            btnEditar.Enabled = true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            comboBoxId.Enabled = true;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void ComboBoxId_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CampoCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }
    }
}
