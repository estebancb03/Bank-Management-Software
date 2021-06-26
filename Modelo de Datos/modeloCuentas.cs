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
    class modeloCuentas
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

        public Boolean buscarCuenta(String ide)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "TablaCuentas");
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
        public void cargarComboCondicion(System.Windows.Forms.ComboBox combo)
        {
            combo.Items.Add("Activa");
            combo.Items.Add("Inactiva");
        }
        //Método para registrar una cuenta
        public void ingresarCuenta(String num, DateTime fecha, String condicion, String saldo, String montoLimite,
        String montoDisponible, String id)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLACUENTAS (NUMEROCUENTA,FECHAAPERTURA,CONDICIONCUENTA,SALDOAPAGAR,MONTOLIMITECREDITO,"+
                "MONTODISPONIBLE,IDENTIFICACION) VALUES (@num,@fecha,@condicion,@saldo,@montoLimite,@montoDisponible,"+
                "@id)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@num", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@condicion", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@saldo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@montoLimite", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@montoDisponible", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
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
        //Método para cargar combo
        public void cargarComboCuentas(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS ORDER BY NUMEROCUENTA", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["NumeroCuenta"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Método para consultar una cuenta 
        public Boolean consultarCuenta(String num, System.Windows.Forms.TextBox campoId, System.Windows.Forms.TextBox campoCondicion,
        System.Windows.Forms.TextBox campoSaldo, System.Windows.Forms.TextBox campoLimite, System.Windows.Forms.TextBox campoMonto, System.Windows.Forms.TextBox campoFecha)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoId.DataBindings.Add("text", oDataSet, "tablacuentas.identificacion");
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablacuentas.condicioncuenta");
                    campoSaldo.DataBindings.Add("text", oDataSet, "tablacuentas.saldoapagar");
                    campoLimite.DataBindings.Add("text", oDataSet, "tablacuentas.montolimitecredito");
                    campoMonto.DataBindings.Add("text", oDataSet, "tablacuentas.montodisponible");
                    campoFecha.DataBindings.Add("text", oDataSet, "tablacuentas.fechaapertura");
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
        //Método que muestra la condición de una cuenta en un comboBox
        public Boolean mostrarCondicionCuenta(String num, System.Windows.Forms.ComboBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablacuentas.condicioncuenta");
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
        public Boolean mostrarCondicionCuenta2(String num, System.Windows.Forms.TextBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablacuentas.condicioncuenta");
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
        //Método que muestra el monto límite de crédito de una cuenta
        public Boolean mostrarMontoLimite(String num, System.Windows.Forms.TextBox campoMonto)
        {

            try
            {
                
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoMonto.DataBindings.Add("text", oDataSet, "tablacuentas.montolimitecredito");
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
        //Método para mostrar el saldo actual de una cuenta
        public Boolean mostrarSaldoCuenta(String num, System.Windows.Forms.TextBox campoSaldo)
        {

            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoSaldo.DataBindings.Add("text", oDataSet, "tablacuentas.saldoapagar");
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
        //Método para mostrar el monto actual de una cuenta
        public Boolean mostrarMontoCuenta(String num, System.Windows.Forms.TextBox campoSaldo)
        {

            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoSaldo.DataBindings.Add("text", oDataSet, "tablacuentas.montodisponible");
                }
                if (oDataAdapter.Fill(oDataSet) == 0)
                {
                    campoSaldo.Text = "0";
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
        //Método para mostrar el monto actual de una cuenta
        public Boolean mostrarMontoCuenta2(String num, System.Windows.Forms.TextBox campoSaldo)
        {

            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoSaldo.DataBindings.Add("text", oDataSet, "tablacuentas.montodisponible");
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
        //Método para modificar la condición de una cuenta
        public Boolean modificarCondicion(String num, String condicion)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET CONDICIONCUENTA = '" + condicion + "'"+
            "WHERE NUMEROCUENTA = '" + num + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para modificar el monto límite de una cuenta
        public Boolean modificarMontoLimite(String num, String monto)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET MONTOLIMITECREDITO = '" + monto + "'" +
            "WHERE NUMEROCUENTA = '" + num + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para modificar el monto disponible de una cuenta
        public Boolean modificarMontoDisponible(String num, String monto)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET MONTODISPONIBLE = '" + monto + "'" +
            "WHERE NUMEROCUENTA = '" + num + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para actualizar el saldo de una cuenta durante un movimiento
        public Boolean actualizarSaldoSuma(String numeroCuenta, Double saldoViejo, Double monto)
        {

            cn.conectarbase();
            oConexion.Open();
            String saldoNuevo;
            saldoNuevo = Convert.ToString(saldoViejo + monto);
            
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET SALDOAPAGAR = '" +saldoNuevo+ "' WHERE NUMEROCUENTA = '" +numeroCuenta+ "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para actualizar el saldo de una cuenta durante un movimiento
        public Boolean actualizarSaldoResta(String numeroCuenta, Double saldoViejo, Double monto)
        {

            cn.conectarbase();
            oConexion.Open();
            String saldoNuevo;
            saldoNuevo = Convert.ToString(saldoViejo - monto);

            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET SALDOAPAGAR = '" + saldoNuevo + "' WHERE NUMEROCUENTA = '" + numeroCuenta + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para restarle al monto límite
        public Boolean actualizarMontoResta(String numeroCuenta, Double montoViejo, Double monto)
        {

            cn.conectarbase();
            oConexion.Open();
            String montoNuevo;
            montoNuevo = Convert.ToString(montoViejo - monto);

            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET MONTODISPONIBLE = '" + montoNuevo + "' WHERE NUMEROCUENTA = '" + numeroCuenta + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para restarle al monto límite
        public Boolean actualizarMontoSuma(String numeroCuenta, Double montoViejo, Double monto)
        {

            cn.conectarbase();
            oConexion.Open();
            String montoNuevo;
            montoNuevo = Convert.ToString(montoViejo + monto);

            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACUENTAS SET MONTODISPONIBLE = '" + montoNuevo + "' WHERE NUMEROCUENTA = '" + numeroCuenta + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para eliminar una cuenta
        public void eliminarCuenta(String numCuenta)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLACUENTAS WHERE NUMEROCUENTA = '" + numCuenta + "'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
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
