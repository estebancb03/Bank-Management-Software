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
    public partial class reporteBitacoraFechas : Form
    {
        //Se instancian clases
        modeloReportes mr = new modeloReportes();

        public reporteBitacoraFechas()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CampoFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                int iResultado = 0;
                mr.reportaGridBitacoraFechas();
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = campoFechaInicio.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = campoFechaFin.Text;
                mr.oConexion.Open();
                iResultado = mr.oDataAdapter.SelectCommand.ExecuteNonQuery();
                mr.oConexion.Close();
                mr.cargaGridBitacora(dataGridView1);
            }
        }

        private void CampoFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                int iResultado = 0;
                mr.reportaGridBitacoraFechas();
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = campoFechaInicio.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = campoFechaFin.Text;
                mr.oConexion.Open();
                iResultado = mr.oDataAdapter.SelectCommand.ExecuteNonQuery();
                mr.oConexion.Close();
                mr.cargaGridBitacora(dataGridView1);
            }
        }
    }
}
