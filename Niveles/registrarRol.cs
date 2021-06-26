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
    public partial class registrarRol : Form
    {
        //Se instancian clases
        modeloNiveles mn = new modeloNiveles();
        menuPrincipal mp = new menuPrincipal();
        modeloUsuarios mu = new modeloUsuarios();
        utilidades uti = new utilidades();
        modeloBitacora mb = new modeloBitacora();

        //Variales
        String cnivel ="";
        String cfuncion = "";
        public registrarRol()
        {
            InitializeComponent();
            campoRol.Enabled = false;
            mu.cargarComboCondicion(comboBoxCondicion);
            mn.cargarComboNiveles(comboBoxNivel);
            mn.cargarComboFunciones(comboBoxFuncion);
        }

        private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarCodigo(comboBoxNivel.Text, textBox1);
            cnivel = textBox1.Text;
            campoRol.Text = cnivel.ToString() + cfuncion.ToString();
        }

        private void ComboBoxFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mn.mostrarCodigoFuncion(comboBoxFuncion.Text, comboBox1);
            cfuncion = comboBox1.Text;
            campoRol.Text = cnivel.ToString() + cfuncion.ToString();
        }

        private void CampoPrueba1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CampoPrueba2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CampoRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            //campoRol.Text = campoPrueba1.Text + campoPrueba2.Text;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (campoRol.Text != string.Empty)
            {
                if (mn.buscarRol(campoRol.Text) == true)
                {
                    MessageBox.Show("Este código de rol ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mn.ingresarRol(this.campoRol.Text, this.textBox1.Text, comboBox1.Text, comboBoxCondicion.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mn.oDataAdapter.InsertCommand.Parameters["@codigor"].Value = this.campoRol.Text;
                    mn.oDataAdapter.InsertCommand.Parameters["@codigon"].Value = cnivel;
                    mn.oDataAdapter.InsertCommand.Parameters["@codigof"].Value = cfuncion;
                    mn.oDataAdapter.InsertCommand.Parameters["@condicion"].Value = this.comboBoxCondicion.Text;

                    mn.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mn.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mn.oConexion.Close(); //Cierra la conexión con la BD

                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Rol", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Rol";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    uti.limpiar14(campoRol, comboBoxNivel, comboBoxFuncion, comboBoxCondicion);
                    MessageBox.Show("El rol #" + campoRol.Text + ", ha sido registrado correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar14(campoRol, comboBoxNivel, comboBoxFuncion, comboBoxCondicion);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
