using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;         //Para manejar conexión a SQL
using System.Data.SqlClient;   //Para ejecutar comandos de SQL desde la clase
using System.Data;
using System.Windows.Forms;

namespace Creditos
{
    class modeloTransacciones
    {
        //Crea la variable cn del tipo de la clase ConexionBase
        public conexionBaseDatos cn = new conexionBaseDatos();

        //Define e instancia la variable oConexion del tipo de objeto SqlConnection
        public SqlConnection oConexion = new SqlConnection("Data Source=DESKTOP-I70AOMM;Initial Catalog=Creditos;Integrated Security=True");

        //Define e instancia la variable oDataSet del tipo de objeto DataSet que es
        //similar al ResultSet en Java
        public DataSet oDataSet = new DataSet();

        //Define e instancia la variable oDataAdapter del tipo de objeto SqlDataAdapter
        //Este objeto permite utilizar y ejecutar las sentencias de SQL en la tabla de BD
        //similar al Statement en Java
        public SqlDataAdapter oDataAdapter = new SqlDataAdapter();

        //Método para buscar si tiene créditos pendientes de pagar
        public Boolean buscarCredito(String numCuenta,String tipo)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand(
                    "SELECT * FROM TABLAMOVIMIENTOS WHERE TIPOMOVIMIENTO = '" +tipo+ "' AND NUMEROCUENTA = '" +numCuenta+ "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "TablaMovimientos");
                //Rellena el DataSet con los datos de la tablacliente
                oConexion.Close(); //Cierra la conexión
                //Si el DataSet es mayor que 0 es pq hubo datos encontrados 
                //con instrucción select
                if (oDataAdapter.Fill(oDataSet) > 0)
                    enco = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta, entonces
                //cierra la conexión
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
            return enco;
        }

        //Método para cargar combo
        public void cargarComboTransacciones(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAMOVIMIENTOS ORDER BY NUMEROMOVIMIENTO", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["NumeroMovimiento"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }

        //Método para generar un número de movimiento
        public Boolean mostrarNumeroTransaccion(System.Windows.Forms.TextBox campoNumero)
        {

            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT TOP 1 * FROM TablaMovimientos ORDER BY NumeroMovimiento DESC", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNumero.DataBindings.Add("text", oDataSet, "tablamovimientos.numeromovimiento");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta, entonces cierra la conexión
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
            return true;
        }

        //Método para ingresar una transacción

        public void ingresarTransaccion(String numCuenta, DateTime fecha, String tipo, String monto, String nombre,
        String detalle, String numTransaccion)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLAMOVIMIENTOS (NUMEROCUENTA,FECHAMOVIMIENTO,TIPOMOVIMIENTO,MONTOMOVIMIENTO,NOMBREDELRESPONSABLE," +
                "DETALLEMOVIMIENTO,NUMEROMOVIMIENTO) VALUES (@numCuenta,@fecha,@tipo,@monto,@nombre,@detalle,@numTransaccion)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@monto", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@detalle", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numTransaccion", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta, entonces cierra la conexión
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Método para ingresar una transacción

        public void ingresarTransaccionAnulada(String numCuenta, DateTime fecha, String tipo, String monto, String nombre,
        String detalle, String numTransaccion)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLAMOVIMIENTOSANULADOS (NUMEROCUENTA,FECHAMOVIMIENTO,TIPOMOVIMIENTO,MONTOMOVIMIENTO,NOMBREDELRESPONSABLE," +
                "DETALLEMOVIMIENTO,NUMEROMOVIMIENTO) VALUES (@numCuenta,@fecha,@tipo,@monto,@nombre,@detalle,@numTransaccion)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@monto", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@detalle", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numTransaccion", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta, entonces cierra la conexión
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Método para consultar una transacción 
        public Boolean consultarTransaccion(String num, System.Windows.Forms.TextBox campoNumCuenta, System.Windows.Forms.TextBox campoTipo,
        System.Windows.Forms.TextBox campoMonto, System.Windows.Forms.TextBox campoResponsable, System.Windows.Forms.TextBox campoDetalle, 
        System.Windows.Forms.TextBox campoFecha)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAMOVIMIENTOS WHERE NUMEROMOVIMIENTO = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNumCuenta.DataBindings.Add("text", oDataSet, "tablamovimientos.numerocuenta");
                    campoTipo.DataBindings.Add("text", oDataSet, "tablamovimientos.tipomovimiento");
                    campoMonto.DataBindings.Add("text", oDataSet, "tablamovimientos.montomovimiento");
                    campoResponsable.DataBindings.Add("text", oDataSet, "tablamovimientos.nombredelresponsable");
                    campoDetalle.DataBindings.Add("text", oDataSet, "tablamovimientos.detallemovimiento");
                    campoFecha.DataBindings.Add("text", oDataSet, "tablamovimientos.fechamovimiento");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta, entonces cierra la conexión
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
            return true;
        }
        public void cargarComboTipo(System.Windows.Forms.ComboBox combo)
        {
            combo.Items.Add("Abono");
            combo.Items.Add("Crédito");
        }
        //Método que permite eliminar una transacción
        public void anularTransaccion(String numTransaccion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLAMOVIMIENTOS WHERE NUMEROMOVIMIENTO = '"+numTransaccion+"'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                //aqui carga o rellena el data set y obtiene los datos de la tablacliente
                oConexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Método que permite eliminar varias transacciones
        public void anularTransaccion2(String numCuenta)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLAMOVIMIENTOS WHERE NUMEROCUENTA = '" + numCuenta + "'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                //aqui carga o rellena el data set y obtiene los datos de la tablacliente
                oConexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
    }
}
