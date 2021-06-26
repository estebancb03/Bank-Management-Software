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
    public partial class reporteTransaccionesCuentaFechas : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloReportes mr = new modeloReportes();

        public reporteTransaccionesCuentaFechas()
        {
            InitializeComponent();
            mcu.cargarComboCuentas(comboBoxNumCuenta);
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void DateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                int iResultado = 0;
                mr.reportaGridTransaccionCuentaFechas();
                mr.oDataAdapter.SelectCommand.Parameters.Add("@numCuenta", SqlDbType.Char).Value = comboBoxNumCuenta.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = campoFechaInicio.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = campoFechaFin.Text;
                mr.oConexion.Open();
                iResultado = mr.oDataAdapter.SelectCommand.ExecuteNonQuery();
                mr.oConexion.Close();
                mr.cargaGridTransacciones(dataGridView1);
            }
        }

        private void CampoFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                int iResultado = 0;
                mr.reportaGridTransaccionCuentaFechas();
                mr.oDataAdapter.SelectCommand.Parameters.Add("@numCuenta", SqlDbType.Char).Value = comboBoxNumCuenta.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = campoFechaInicio.Text;
                mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = campoFechaFin.Text;
                mr.oConexion.Open();
                iResultado = mr.oDataAdapter.SelectCommand.ExecuteNonQuery();
                mr.oConexion.Close();
                mr.cargaGridTransacciones(dataGridView1);
            }
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iResultado = 0;
            mr.reportaGridTransaccionCuentaFechas();
            mr.oDataAdapter.SelectCommand.Parameters.Add("@numCuenta", SqlDbType.Char).Value = comboBoxNumCuenta.Text;
            mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime).Value = campoFechaInicio.Text;
            mr.oDataAdapter.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime).Value = campoFechaFin.Text;
            mr.oConexion.Open();
            iResultado = mr.oDataAdapter.SelectCommand.ExecuteNonQuery();
            mr.oConexion.Close();
            mr.cargaGridTransacciones(dataGridView1);
        }
    }
}
