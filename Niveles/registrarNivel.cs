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
    public partial class registrarNivel : Form
    {
        //Se instancian clases
        utilidades uti = new utilidades();
        validaciones va = new validaciones();
        menuPrincipal mp = new menuPrincipal();
        modeloNiveles mn = new modeloNiveles();
        modeloBitacora mb = new modeloBitacora();
        public registrarNivel()
        {
            InitializeComponent();
        }

        private void RegistrarNivel_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar13(campoCodigo,campoNombre);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int iResultado = 0;
            if (campoCodigo.Text != string.Empty || campoNombre.Text != string.Empty)
            {
                if (mn.buscarCodigo(campoCodigo.Text) == true)
                {
                    MessageBox.Show("El código ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    mn.ingresarNivel(this.campoCodigo.Text, this.campoNombre.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mn.oDataAdapter.InsertCommand.Parameters["@codigo"].Value = this.campoCodigo.Text;
                    mn.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                    mn.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mn.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mn.oConexion.Close(); //Cierra la conexión con la BD

                    //Bitácora
                    DateTime fecha = DateTime.Now;
                    mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Nivel", mp.campoLogin.Text);
                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                    mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                    mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Nivel";
                    mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                    mb.oConexion.Open(); //Abre la conexión con la BD
                    iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                    mb.oConexion.Close(); //Cierra la conexión con la BD

                    MessageBox.Show("El nivel #" + campoCodigo.Text + ", ha sido registrado correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uti.limpiar13(campoCodigo, campoNombre);
                }
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CampoCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CampoNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CampoCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
        }

        private void CampoCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
