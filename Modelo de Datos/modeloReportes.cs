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
    class modeloReportes
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

        //Este procedimiento carga los datos en el Grid, una vez que se han guardado
        //los datos en el DataSet por medio de la instrucción en SQL correspondiente
        public void cargaGridCuentas(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablacuentas");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablacuentas"; //Indica que los datos se obtienen de tablacuentas

        }
        public void cargaGridTransacciones(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablamovimientos");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablamovimientos"; //Indica que los datos se obtienen de tablacuentas

        }
        public void cargaGridDetalles(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tabladetallecompras");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tabladetallecompras"; //Indica que los datos se obtienen de tablacuentas

        }
        public void cargaGridClientes(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablaclientes");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablaclientes"; //Indica que los datos se obtienen de tablacuentas

        }
        public void cargaGridUsuarios(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablausuarios");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablausuarios"; //Indica que los datos se obtienen de tablacuentas
        }
        public void cargaGridRoles(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablaroles");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablaroles"; //Indica que los datos se obtienen de tablacuentas
        }
        public void cargaGridBitacora(DataGridView grid)
        {
            oDataSet.Clear();
            oConexion.Open(); //Abre la conexión
            oDataAdapter.Fill(oDataSet, "tablabitacoras");
            //Carga en el DataSet y obtiene los datos de la tablacliente
            oConexion.Close();
            grid.DataSource = oDataSet; //Carga los datos del DataSet en el Grid
            grid.DataMember = "tablabitacoras"; //Indica que los datos se obtienen de tablacuentas
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridCuentasTodas()
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridCuentasCondicion(String condicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACUENTAS WHERE CONDICIONCUENTA LIKE '" + condicion + "%'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablacuentas");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridTransaccionCuenta(String numCuenta)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAMOVIMIENTOS WHERE NUMEROCUENTA LIKE '" + numCuenta + "%'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridDetallesCuenta(String numCuenta)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLADETALLECOMPRAS WHERE NUMEROCUENTA LIKE '" + numCuenta + "%'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tabladetallecomptras");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridClientesNombre(String nombre)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACLIENTES WHERE NOMBRECLIENTE LIKE '" + nombre + "%'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaclientes");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridTransaccionCuentaFechas()
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAMOVIMIENTOS WHERE FECHAMOVIMIENTO BETWEEN @fecha1 AND @fecha2 " +
                "AND NUMEROCUENTA = @numCuenta", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;

                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha1",SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha2", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridTransaccionesTipo(String num, String tipo)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAMOVIMIENTOS WHERE NUMEROCUENTA LIKE '" + num + "%' AND TIPOMOVIMIENTO = '"+tipo+"'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablamovimientos");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridUsuariosTodos()
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridUsuariosNivel(String codigo)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE CODIGONIVEL = '" + codigo + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridRolesTodos()
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaroles");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridRolesNivel(String nivel)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES WHERE CODIGONIVEL = '"+nivel+"'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaroles");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        //Procedimiento que ejecuta la instrucción en SQL para que cargue los datos donde
        //el nombre sea parecido (like) al nom que recibe como parámetro
        public void reportaGridBitacoraUsuario(String login)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLABITACORAS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablabitacoras");
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
        public void reportaGridBitacoraFechas()
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLABITACORAS WHERE FECHAMOVIMIENTO BETWEEN @fecha1 AND @fecha2 ", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;

                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha1", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha2", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //aqui pregunta si el estado de la conexion está abierta, entonces 
                //cierra la conexion
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }
    }
}
