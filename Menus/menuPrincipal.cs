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
    public partial class menuPrincipal : Form
    {
        //Se inicializan clases
        utilidades uti = new utilidades();
        modeloUsuarios mu = new modeloUsuarios();
        modeloNiveles mn = new modeloNiveles();
        inicioSesion ise = new inicioSesion();

        public menuPrincipal()
        {
            InitializeComponent();

            String cod = textBox2.Text;

            uti.bloquear1(true, campoLogin, campoId, campoNombre, campoApellido, textBox1, campoCondicion);
            /*uti.bloquearMenu(true, toolStripMenuItem2, toolStripMenuItem3, eliminarUsuarioToolStripMenuItem,
            toolStripMenuItem9, todosLosUsuariosToolStripMenuItem, toolStripMenuItem7, toolStripMenuItem10, todasLasCuentasToolStripMenuItem,
            toolStripMenuItem13, toolStripMenuItem14, transaccionesDeUnaCuentaToolStripMenuItem, toolStripMenuItem11, toolStripMenuItem12,
            toolStripMenuItem16, toolStripMenuItem17, todasLasFuncionesDeUnNivelToolStripMenuItem, movimientosEnUnRangoDeFechasToolStripMenuItem,
            toolStripMenuItem15, registrarClienteToolStripMenuItem, toolStripMenuItem20, toolStripMenuItem19, toolStripMenuItem18,
            condiciónToolStripMenuItem1, toolStripMenuItem23, toolStripMenuItem22, montoLímiteDeCréditoToolStripMenuItem, registrarCuentaToolStripMenuItem,
            toolStripMenuItem28, toolStripMenuItem25, toolStripMenuItem24, registrarTransacciónToolStripMenuItem, toolStripMenuItem27,
            toolStripMenuItem26, toolStripMenuItem29, datosToolStripMenuItem, condicionToolStripMenuItem);
            habilitaOpciones();*/
        }

        private void Ise_pasado(string dato)
        {
            throw new NotImplementedException();
        }
        #region utilidades

        //Método para abrir un formulario dentro del panel
        public void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = new MiForm();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formulario);
            panelFormularios.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
        }

        #endregion

        public void habilitaOpciones()
        {
           // if (ise.v.Contains("tome mil")) toolStripMenuItem3.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "01")) == true) toolStripMenuItem2.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "02")) == true) datosToolStripMenuItem.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "03")) == true) condicionToolStripMenuItem.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "04")) == true) eliminarUsuarioToolStripMenuItem.Enabled = true;

            if (mn.buscarRol(String.Concat(textBox1.Text, "05")) == true) toolStripMenuItem9.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "06")) == true) todosLosUsuariosToolStripMenuItem.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "07")) == true) toolStripMenuItem7.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "08")) == true) toolStripMenuItem10.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "09")) == true) todasLasCuentasToolStripMenuItem.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "10")) == true) toolStripMenuItem14.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "11")) == true) toolStripMenuItem13.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "12")) == true) transaccionesDeUnaCuentaToolStripMenuItem.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "13")) == true) toolStripMenuItem11.Enabled = true;
            if (mn.buscarRol(String.Concat(textBox1.Text, "14")) == true) toolStripMenuItem12.Enabled = true;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void abandonarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abandonarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Se inicializan clases
            inicioSesion ise = new inicioSesion();
            ise.Visible = true;
        }

        private void menúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<resgistrarUsuario>();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<consultarUsuario>();
        }

        private void transaccionesDeUnaCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteDetalleCuenta>();
        }

        private void movimientosEnUnRangoDeFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteBitacoraUsuarios>();
        }

        private void registrarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<eliminarCuenta>();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarCliente>();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            AbrirFormulario<consultarCliente>();
        }

        private void ToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            AbrirFormulario<modificarCliente>();
        }

        private void RegistrarCleinteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<eliminarCliente>();
        }

        private void ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarCuentas>();
        }

        private void ToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            AbrirFormulario<consultarCuentas>();
        }

        private void CondiciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<modificarCondicionCuenta>();
        }

        private void MontoLímiteDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<modificarMontoLimiteCredito>();
        }

        private void ToolStripMenuItem25_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarTransaccion>();
        }

        private void ToolStripMenuItem28_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarCredito>();
        }

        private void ToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            AbrirFormulario<consultarTransaccion>();
        }

        private void RegistrarTransacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<anularTransaccion>();
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteCuentasTodas>();
        }

        private void TodasLasCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reportarCuentasActivacion>();
        }

        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteTransaccionesCuenta>();
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteClientes>();
        }

        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteTransaccionesCuentaFechas>();
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteTransaccionesTipo>();
        }

        private void RegistrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<eliminarUsuario>();
        }

        private void CondiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<modificarCondicionUsuario>();
        }

        private void DatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<modificarDatosUsuario>();
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteUsuariosTodos>();
        }

        private void ToolStripMenuItem27_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarNivel>();
        }

        private void TodosLosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteUsuariosNivel>();
        }

        private void ToolStripMenuItem29_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarFuncion>();
        }

        private void NivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem26_Click(object sender, EventArgs e)
        {
            AbrirFormulario<registrarRol>();
        }

        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteRolesTodos>();
        }

        private void ToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteRolesNivel>();
        }

        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            AbrirFormulario<reporteBitacoraFechas>();
        }

        private void RegistrarNivelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ModificarRol>();
        }

        private void ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
           // AbrirFormulario<repor>
        }
    }
}
