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
    public partial class eliminarCliente : Form
    {
        //Se instancian clases
        menuPrincipal mp = new menuPrincipal();
        modeloClientes mc = new modeloClientes();
        modeloCuentas mcu = new modeloCuentas();
        utilidades uti = new utilidades();
        modeloBitacora mb = new modeloBitacora();

        DateTime fecha = DateTime.Now;

        public eliminarCliente()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            mc.cargarComboId(comboBoxId);
            uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void EliminarCliente_Load(object sender, EventArgs e)
        {

        }

        private void ComboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = comboBoxId.Text;
            mc.consultarCliente(id, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            btnEliminar.Enabled = true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
            btnEliminar.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            String id = comboBoxId.Text;
            if(MessageBox.Show("¿Desea Eliminar el Cliente #"+id+"?", "Eliminar",MessageBoxButtons.YesNoCancel, 
            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(mcu.buscarCuenta(id) == true)
                {
                    MessageBox.Show("El cliente #" + id + "tiene cuentas abiertas, cierre las cuentas para poder " +
                    "eliminar al cliente", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    btnEliminar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El cliente #" + id + " ha sido elimindo correctamente", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    mc.eliminarCliente(id);
                    comboBoxId.Items.Clear();
                    mc.cargarComboId(comboBoxId);
                    uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                    btnEliminar.Enabled = false;

                    //Bitácora
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Eliminación Cliente", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Eliminación Cliente";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                }
            }
            else
            {
                MessageBox.Show("El cliente #"+id+"no ha sido elimindo", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                uti.bloquear2(true, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                uti.limpiar2(comboBoxId, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
                btnEliminar.Enabled = false;
            }
        }
    }
}
