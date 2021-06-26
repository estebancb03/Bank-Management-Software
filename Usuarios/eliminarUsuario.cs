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
    public partial class eliminarUsuario : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        modeloNiveles mn = new modeloNiveles();
        modeloBitacora mb = new modeloBitacora();

        public eliminarUsuario()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
            mu.cargarComboLogin(comboBoxLogin);
            uti.bloquear3(true, campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar11(comboBoxLogin, campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
        }
        private void ComboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            mu.consultarUsuario(comboBoxLogin.Text, campoPassword, campoId, campoNombre, campoApellido, campoPrueba, campoCondicion, campoFecha);
            mn.mostrarNombre2(campoPrueba.Text, campoNivel);
            btnEliminar.Enabled = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar al usuario " +comboBoxLogin.Text+ "?", "Eliminar", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("El usuario " + comboBoxLogin.Text + " ha sido elimindo correctamente", "Informacion", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                mu.eliminarUsuario(comboBoxLogin.Text);
                comboBoxLogin.Items.Clear();
                mu.cargarComboLogin(comboBoxLogin);

                //Bitácora
                DateTime fecha = DateTime.Now;
                int iResultado = 0;
                mb.ingresarBitacora(Convert.ToDateTime(fecha), "Eliminación Usuario", mp.campoLogin.Text);
                //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Eliminación Usuario";
                mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                mb.oConexion.Open(); //Abre la conexión con la BD
                iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                mb.oConexion.Close(); //Cierra la conexión con la BD

                btnEliminar.Enabled = false;
                uti.bloquear3(true, campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
                uti.limpiar11(comboBoxLogin, campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
            }
        }
    }
}
