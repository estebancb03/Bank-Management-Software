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
    public partial class registrarCredito : Form
    {
        //Se inicializan clases
        utilidades uti = new utilidades();
        validaciones va = new validaciones();
        menuPrincipal mp = new menuPrincipal();
        modeloCuentas mcu = new modeloCuentas();
        modeloDetalles md = new modeloDetalles();
        modeloBitacora mb = new modeloBitacora();
        modeloTransacciones mt = new modeloTransacciones();

        //Variables globales
        public static int contFila = 0;
        public static double monto = 0;
        double subtotalEliminar = 0;
        int numFila = 0;

        public registrarCredito()
        {
            InitializeComponent();
            campoMonto.Enabled = false;
            campoSubtotal.Enabled = false;
            campoNumeroTransaccion.Enabled = false;
            campoMonto.Text = "₡" + monto;
            campoSubtotal.Text = "₡" + 0;
            mcu.cargarComboCuentas(comboBoxNumCuenta);
            mt.mostrarNumeroTransaccion(campoPruebaNumero);
        }

        private void RegistrarCredito_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            mp.AbrirFormulario<inicio>();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int iResultado;
            int dResultado;
            if((campoCondicion.Text).Contains("Activa"))
            {
                if (comboBoxNumCuenta.Text == "" || campoNumeroTransaccion.Text == "" ||
                campoMonto.Text == "" || campoNombre.Text == "" || campoFecha.Text == "" || campoDetalle.Text == "")
                {
                    MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxNumCuenta.Focus();
                }
                else
                {
                    if (monto <= Convert.ToDouble(campoLimite.Text))
                    {
                        if (monto != 0)
                        {
                            mt.ingresarTransaccion(this.comboBoxNumCuenta.Text, Convert.ToDateTime(campoFecha.Text), "Credito",
                            campoMonto.Text, campoNombre.Text, campoDetalle.Text, campoNumeroTransaccion.Text);

                            //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                            mt.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value = this.comboBoxNumCuenta.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                            mt.oDataAdapter.InsertCommand.Parameters["@tipo"].Value = "Credito";
                            mt.oDataAdapter.InsertCommand.Parameters["@monto"].Value = monto;
                            mt.oDataAdapter.InsertCommand.Parameters["@nombre"].Value = this.campoNombre.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@detalle"].Value = this.campoDetalle.Text;
                            mt.oDataAdapter.InsertCommand.Parameters["@numTransaccion"].Value = this.campoNumeroTransaccion.Text;
                            mt.oConexion.Open(); //Abre la conexión con la BD
                            iResultado = mt.oDataAdapter.InsertCommand.ExecuteNonQuery();
                            //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                            mt.oConexion.Close(); //Cierra la conexión con la BD

                            //Bitácora
                            DateTime fecha = DateTime.Now;
                            mb.ingresarBitacora(Convert.ToDateTime(fecha), "Registro Credito", mp.campoLogin.Text);
                            //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                            mb.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(fecha);
                            mb.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = "Registro Credito";
                            mb.oDataAdapter.InsertCommand.Parameters["@login"].Value = mp.campoLogin.Text;
                            mb.oConexion.Open(); //Abre la conexión con la BD
                            iResultado = mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                            //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                            mb.oConexion.Close(); //Cierra la conexión con la BD

                            mcu.actualizarSaldoSuma(comboBoxNumCuenta.Text, Convert.ToDouble(campoSaldoViejo.Text), monto);
                            mcu.actualizarMontoResta(comboBoxNumCuenta.Text, Convert.ToDouble(campoLimite.Text), monto);

                            foreach (DataGridViewRow fila in dataGridView1.Rows)
                            {
                                numFila = fila.Index;
                                md.ingresarDetalle(comboBoxNumCuenta.Text, campoNumeroTransaccion.Text, Convert.ToDateTime(campoFecha.Text), 
                                campoDetalle.Text,campoMonto.Text);
                                //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el modelo
                                md.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value = this.comboBoxNumCuenta.Text;
                                md.oDataAdapter.InsertCommand.Parameters["@numTransaccion"].Value = this.campoNumeroTransaccion.Text;
                                md.oDataAdapter.InsertCommand.Parameters["@fecha"].Value = Convert.ToDateTime(this.campoFecha.Text);
                                md.oDataAdapter.InsertCommand.Parameters["@descripcion"].Value = dataGridView1.Rows[numFila].Cells[0].Value;
                                md.oDataAdapter.InsertCommand.Parameters["@monto"].Value = dataGridView1.Rows[numFila].Cells[1].Value;
                                md.oDataAdapter.InsertCommand.Parameters["@cantidad"].Value = dataGridView1.Rows[numFila].Cells[2].Value;
                                md.oConexion.Open(); //Abre la conexión con la BD
                                dResultado = md.oDataAdapter.InsertCommand.ExecuteNonQuery(); //Ejecuta la inserción en la tabla de la BD mediante el oDataAdapter
                                md.oConexion.Close(); //Cierra la conexión con la BD
                            }


                            MessageBox.Show("Transacción #" + campoNumeroTransaccion.Text + " registrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.Rows.Clear(); //Limpia la tabla
                            uti.limpiar9(comboBoxNumCuenta, campoNombre, campoDetalle, campoFecha, campoArticulo, campoPrecio, campoCantidad, campoNumeroTransaccion);
                            //Se reinician variables
                            contFila = 0;
                            monto = 0;
                            double subtotal = 0;
                            campoMonto.Text = "₡" + monto;
                            campoSubtotal.Text = "₡" + subtotal;
                        }
                        else
                        {
                            MessageBox.Show("El monto del crédito que desea adquirir no es válido", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El monto del crédito que desea adquirir es mayor al permitido", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Imposible realizar la transacción, la cuenta está inactiva", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void CampoTipo_TextChanged(object sender, EventArgs e)
        {

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(!(campoArticulo.Text == "" || campoPrecio.Text == "" || campoCantidad.Text == ""))
            {
                bool existe = false;
                //int numFila = 0;
                double subtotal = 0;

                if (contFila == 0)
                {
                    dataGridView1.Rows.Add(campoArticulo.Text, campoPrecio.Text, campoCantidad.Text); //Agrega a la tabla
                    double importe = Convert.ToDouble(dataGridView1.Rows[contFila].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[contFila].Cells[2].Value);
                    dataGridView1.Rows[contFila].Cells[3].Value = importe;
                    contFila++;
                }
                else
                {
                    foreach(DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if(Convert.ToString(fila.Cells[0].Value) == campoArticulo.Text)
                        {
                            existe = true;
                            numFila = fila.Index;
                        }
                    }
                    if(existe == true)
                    {
                        dataGridView1.Rows[numFila].Cells[2].Value = (Convert.ToDouble(campoCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[numFila].Cells[2].Value)).ToString();
                        double importe = Convert.ToDouble(dataGridView1.Rows[numFila].Cells[1].Value) *  Convert.ToDouble(dataGridView1.Rows[numFila].Cells[2].Value);
                        dataGridView1.Rows[numFila].Cells[3].Value = importe;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(campoArticulo.Text, campoPrecio.Text, campoCantidad.Text); //Agrega a la tabla
                        double importe = Convert.ToDouble(dataGridView1.Rows[contFila].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[contFila].Cells[2].Value);
                        dataGridView1.Rows[contFila].Cells[3].Value = importe;
                        contFila++;
                    }
                }
                foreach (DataGridViewRow fila in dataGridView1.Rows) //Foreach para calcular el subtotal 
                {
                    subtotal += Convert.ToDouble(fila.Cells[3].Value); //Suma los importes de cada fila
                }
                monto = (subtotal * 0.13) + subtotal;
                campoSubtotal.Text = "₡" + subtotal.ToString();
                campoMonto.Text = "₡" + monto.ToString();
                subtotalEliminar = subtotal;
                uti.limpiar8(campoArticulo,campoPrecio,campoCantidad);
            }
            else
            {
                MessageBox.Show("Faltan datos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (campoArticulo.Text == "") campoArticulo.Focus();
                if (campoPrecio.Text == "") campoPrecio.Focus();
                if (campoCantidad.Text == "") campoCantidad.Focus();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            double subtotal = subtotalEliminar;
            if(contFila > 0)
            {
                if(contFila == 1)
                {
                    subtotal = 0;
                    monto = 0;
                    campoSubtotal.Text = "₡" + subtotal.ToString();
                    campoMonto.Text = "₡" + monto.ToString();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); //Elimina la fila seleccionada
                    contFila--;
                }
                else
                {
                    subtotal = subtotal - Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value);
                    monto = (subtotal * 0.13) + subtotal;
                    campoSubtotal.Text = "₡" + subtotal.ToString();
                    campoMonto.Text = "₡" + monto.ToString();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index); //Elimina la fila seleccionada
                    contFila--;
                }
            }
            else
            {
                MessageBox.Show("No hay datos que se puedan eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); //Limpia la tabla
            uti.limpiar9(comboBoxNumCuenta, campoNombre, campoDetalle, campoFecha, campoArticulo, campoPrecio, campoCantidad, campoNumeroTransaccion);
            //Se reinician variables
            contFila = 0;
            monto = 0;
            double subtotal = 0;
            campoMonto.Text = "₡" + monto;
            campoSubtotal.Text = "₡" + subtotal;
        }

        private void ComboBoxNumCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcu.mostrarSaldoCuenta(comboBoxNumCuenta.Text, campoSaldoViejo);
            mcu.mostrarMontoCuenta(comboBoxNumCuenta.Text, campoLimite);
            mcu.mostrarCondicionCuenta2(comboBoxNumCuenta.Text, campoCondicion);
            if(campoPruebaNumero.Text != "")
            {
                campoNumeroTransaccion.Text = (Convert.ToDouble(campoPruebaNumero.Text) + 1).ToString();
            }
            else
            {
                campoNumeroTransaccion.Text = "1";
            }
        }

        private void CampoCondicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CampoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CampoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloLetras(e);
        }

        private void CampoPrecio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CampoPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }

        private void CampoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            va.soloNumeros(e);
        }
    }
}
