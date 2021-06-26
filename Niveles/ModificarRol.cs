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
    public partial class ModificarRol : Form
    {
        //Inicializar clases
        modeloNiveles mn = new modeloNiveles();
        modeloUsuarios mu = new modeloUsuarios();
        modeloBitacora mb = new modeloBitacora();
        menuPrincipal mp = new menuPrincipal();
        utilidades uti = new utilidades();

        public ModificarRol()
        {
            InitializeComponent();
            mn.cargarComboRoles(comboBoxRol);
            mu.cargarComboCondicion(comboBoxCondicion);
            comboBoxCondicion.Enabled = false;
            btnGuardar.Enabled = false;
            campoNivel.Enabled = false;
            campoFuncion.Enabled = false;
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarNivel(comboBoxRol.Text, campoNivel);
            mn.mostrarFuncion(comboBoxRol.Text, campoFuncion);
            mn.mostrarCondicionRol(comboBoxRol.Text,comboBoxCondicion);
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            comboBoxCondicion.Enabled = true;
            comboBoxRol.Enabled = false;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(comboBoxRol.Text == "" || comboBoxCondicion.Text == ""))
            {

                if (mn.modificarRol(comboBoxRol.Text, comboBoxCondicion.Text) == true)
                {
                    MessageBox.Show("El rol #" + comboBoxRol.Text + " ha sido modificado correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar15(comboBoxRol,campoNivel,campoFuncion,comboBoxCondicion);
                    comboBoxCondicion.Enabled = false;
                    comboBoxRol.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    int iResultado = 0;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Modificación Rol", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Modificación Rol";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD
                }
                else
                {
                    MessageBox.Show("El rol #" + comboBoxRol.Text + " no ha sido modificado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uti.limpiar15(comboBoxRol, campoNivel, campoFuncion, comboBoxCondicion);
            comboBoxCondicion.Enabled = false;
            comboBoxRol.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
        }
    }
}
