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
    public partial class consultarUsuario : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        conexionBaseDatos cn = new conexionBaseDatos();
        modeloNiveles mn = new modeloNiveles();

        public consultarUsuario()
        {
            InitializeComponent();
            mu.cargarComboLogin(comboBoxLogin);
            uti.bloquear3(true,campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar11(comboBoxLogin, campoPassword, campoId, campoNombre, campoApellido, campoNivel, campoCondicion, campoFecha);
            comboBoxLogin.Enabled = true;
        }
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (comboBoxLogin.Text != "")
            {
                comboBoxLogin.Enabled = false;
                mu.consultarUsuario(comboBoxLogin.Text, campoPassword, campoId, campoNombre, campoApellido, campoPrueba, campoCondicion, campoFecha);
                mn.mostrarNombre2(campoPrueba.Text, campoNivel);
            } 
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxLogin.Focus();
            }
        }

        private void ConsultarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
