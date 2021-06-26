using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Creditos;

namespace Creditos
{
    public partial class inicioSesion : Form
    {
        //Se instancian clases
        modeloUsuarios mu = new modeloUsuarios();
        modeloNiveles mn = new modeloNiveles();
        modeloBitacora mb = new modeloBitacora();

        public static string loginUsuario = "";
        public static String usu = "";

        public inicioSesion()
        {
            InitializeComponent();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            
        }

        private void CampoUsuario_Enter(object sender, EventArgs e)
        {
            if(campoUsuario.Text == "USUARIO")
            {
                campoUsuario.Text = "";
                campoUsuario.ForeColor = Color.LightGray;
            }
        }
        
        private void CampoUsuario_Leave(object sender, EventArgs e)
        {
            if (campoUsuario.Text == "")
            {
                campoUsuario.Text = "USUARIO";
                campoUsuario.ForeColor = Color.DimGray;
            }
            if (campoUsuario.Text != "")
            {
                menuPrincipal mp = new menuPrincipal();
                mu.validarPassword(campoUsuario.Text, textBox1);
                mu.mostrarCondicionUsuario2(campoUsuario.Text, textBox2);
                usu = campoUsuario.Text;
                mu.mostrarCondicionNivel(usu, textBox3);
                mp.textBox3.Text = this.textBox3.Text;
            }
        }

        private void CampoPassword_Enter(object sender, EventArgs e)
        {
            if (campoPassword.Text == "CONTRASEÑA")
            {
                campoPassword.Text = "";
                campoPassword.ForeColor = Color.LightGray;
                campoPassword.UseSystemPasswordChar = true;
            }
        }
        private void CampoPassword_Leave(object sender, EventArgs e)
        {
            if (campoPassword.Text == "")
            {
                campoPassword.Text = "CONTRASEÑA";
                campoPassword.ForeColor = Color.DimGray;
                campoPassword.UseSystemPasswordChar = false;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            string password = campoPassword.Text;
            if(campoUsuario.Text != "" && campoPassword.Text != "")
            {
                if (mu.buscarLogin(campoUsuario.Text) == true && textBox1.Text.Contains(password))
                {
                    if (textBox2.Text.Contains("Activo"))
                    {
                        menuPrincipal mp = new menuPrincipal();
                        mp.campoLogin.Text = campoUsuario.Text;
                        usu = campoUsuario.Text;
                        this.Hide();
                        mu.consultarUsuario3(usu, mp.campoId, mp.campoNombre, mp.campoApellido, mp.textBox1, mp.campoCondicion);
                        mp.Show();

                        //Bitácora
                        DateTime fecha = DateTime.Now;
                        int iResultado = 0;
                        mb.ingresarBitacora(Convert.ToDateTime(fecha), "Inicio Sesión", this.campoUsuario.Text);
                        //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                        mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                        mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Inicio Sesión";
                        mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = this.campoUsuario.Text;
                        mb.oConexion.Open(); //Abre la conexión con la BD
                        iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                        //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                        mb.oConexion.Close(); //Cierra la conexión con la BD
                    }
                    else
                    {
                        MessageBox.Show("Usuario inactivo, imposible iniciar sesión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        campoUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, por favor verifique los datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar", "Información",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
