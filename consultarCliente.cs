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
    public partial class consultarCliente : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloClientes mc = new modeloClientes();
        utilidades uti = new utilidades();

        public consultarCliente()
        {
            InitializeComponent();
            mc.cargarComboId(comboBoxId);
            uti.bloquear2(true,campoNombre,campoTelefono,campoDireccion,campoCorreo,campoFecha);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            uti.limpiar2(comboBoxId,campoNombre,campoTelefono,campoDireccion,campoCorreo,campoFecha);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            String id = comboBoxId.Text;
            mc.consultarCliente(id, campoNombre, campoTelefono, campoDireccion, campoCorreo, campoFecha);
        }
    }
}
