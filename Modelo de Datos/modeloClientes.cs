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
    class modeloClientes
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

        //Función que permite buscar una identificación en la tabla para ver si existe
        public Boolean buscarId(String ide)
        {
            bool enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand(
                    "SELECT * FROM TABLACLIENTES WHERE IDENTIFICACION = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "TablaClientes");
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

        //Método para ingresar cliente
        public void ingresarCliente(String id, String nombre, String telefono, String direccion, String correo, DateTime fecha)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLACLIENTES (IDENTIFICACION,NOMBRECLIENTE,TELEFONO,DIRECCION,CORREO,FECHAREGISTRO) " +
                "VALUES (@identificacion,@nombre,@telefono,@direccion,@correo,@fecha)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@identificacion", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
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
        public void cargarComboId(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACLIENTES", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["Identificacion"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Método para consultar cliente
        public Boolean consultarCliente(String ide, System.Windows.Forms.TextBox campoNombre, System.Windows.Forms.TextBox campoTelefono,
        System.Windows.Forms.TextBox campoDireccion, System.Windows.Forms.TextBox campoCorreo, System.Windows.Forms.TextBox campoFecha)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLACLIENTES WHERE IDENTIFICACION = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaclientes");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNombre.DataBindings.Add("text", oDataSet, "tablaclientes.nombrecliente");
                    campoTelefono.DataBindings.Add("text", oDataSet, "tablaclientes.telefono");
                    campoDireccion.DataBindings.Add("text", oDataSet, "tablaclientes.direccion");
                    campoCorreo.DataBindings.Add("text", oDataSet, "tablaclientes.correo");
                    campoFecha.DataBindings.Add("text", oDataSet, "tablaclientes.fecharegistro");
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
        //Método que permite modificar los datos de un cliente
        public Boolean modificarCliente(String id,String nombre,String telefono,String direccion,String correo)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLACLIENTES SET NOMBRECLIENTE = '"+nombre+"',"+
            "TELEFONO = '"+telefono+"',DIRECCION = '"+direccion+"',CORREO = '"+correo+"' WHERE IDENTIFICACION = '"+id+"'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0)
                return true;
            else
                return false;
        }
        //Método que permite eliminar a un cliente
        public void eliminarCliente(String id)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLACLIENTES WHERE IDENTIFICACION = '"+id+"'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaclientes");
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
