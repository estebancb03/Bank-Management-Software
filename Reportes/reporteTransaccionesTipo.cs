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
    public partial class reporteTransaccionesTipo : Form
    {
        //Se inicializan clases
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloReportes mr = new modeloReportes();
        modeloTransacciones mt = new modeloTransacciones();

        //Se declaran variables globales
        static double totCreditos = 0;
        static double totAbonos = 0;

        public reporteTransaccionesTipo()
        {
            InitializeComponent();
            campoAbonos.Enabled = false;
            campoCreditos.Enabled = false;
            mt.cargarComboTipo(comboBoxTipo);
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            campoAbonos.Text = "₡" + totAbonos.ToString(); ;
            campoCreditos.Text = "₡" + totCreditos.ToString(); 
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mr.reportaGridTransaccionesTipo(comboBoxNumCuenta.Text,comboBoxTipo.Text);
            mr.cargaGridTransacciones(dataGridView1);

            double totCreditos = 0;
            double totAbonos = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells[2].Value.ToString() == "Abono")
                {
                    totAbonos += Convert.ToDouble(fila.Cells[3].Value);

                }
            }
            campoAbonos.Text = "₡" + totAbonos.ToString();
        }
    }
}
