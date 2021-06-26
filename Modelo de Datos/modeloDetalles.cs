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
    class modeloDetalles
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

        // Metodo para ingresar detalle
        public void ingresarDetalle(String numCuenta, String numTransaccion, DateTime fecha, String descripcion, String monto)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLADETALLECOMPRAS (NUMEROCUENTA,NUMEROMOVIMIENTO,FECHACOMPRA,DESCRIPCION,MONTOCOMPRA,CANTIDADCOMPRA) VALUES " +
                "(@numCuenta,@numTransaccion,@fecha,@descripcion,@monto,@cantidad)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@numTransaccion", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@monto", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.VarChar));
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
        //Método para eliminar los detalles de compra
        public void eliminarDetalle(String numTransaccion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLADETALLECOMPRAS WHERE NUMEROMOVIMIENTO = '" + numTransaccion + "'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tabladetallecompras");
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
