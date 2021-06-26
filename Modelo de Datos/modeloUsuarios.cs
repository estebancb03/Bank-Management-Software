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
    class modeloUsuarios
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

        //Método para buscar un login en la base de datos
        public Boolean buscarLogin(String login)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "TablaUsuarios");
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
        //Método para consultar usuario
        public Boolean validarPassword(String login, System.Windows.Forms.TextBox campoPassword)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoPassword.DataBindings.Add("text", oDataSet, "tablausuarios.password");
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

        //Método para registrar un usuario
        public void ingresarUsuario(String id, String nombre, String apellido, DateTime fecha, String login,
        String password, String codnivel, String condicion)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand(
                "INSERT INTO TABLAUSUARIOS (IDENTIFICACION,NOMBRE,APELLIDOS,FECHAREGISTRO,LOGINUSUARIO,PASSWORD,CODIGONIVEL,CONDICION)" +
                "VALUES (@id,@nombre,@apellido,@fecha,@login,@password,@codNivel,@condicion)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codnivel", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@condicion", SqlDbType.VarChar));
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
        public void cargarComboCondicion(System.Windows.Forms.ComboBox combo)
        {
            combo.Items.Add("Activo");
            combo.Items.Add("Inactivo");
        }
        public void cargarComboNivel(System.Windows.Forms.ComboBox combo)
        {
            combo.Items.Add("Administrativo");
            combo.Items.Add("Operacional");
            combo.Items.Add("Visita");
        }
        //Método para cargar combo
        public void cargarComboLogin(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["loginusuario"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Método para consultar usuario
        public Boolean consultarUsuario(String login, System.Windows.Forms.TextBox campoPassword, System.Windows.Forms.TextBox campoId,
        System.Windows.Forms.TextBox campoNombre, System.Windows.Forms.TextBox campoApellido, System.Windows.Forms.TextBox campoNivel,
        System.Windows.Forms.TextBox campoCondicion, System.Windows.Forms.TextBox campoFecha)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoPassword.DataBindings.Add("text", oDataSet, "tablausuarios.password");
                    campoId.DataBindings.Add("text", oDataSet, "tablausuarios.identificacion");
                    campoNombre.DataBindings.Add("text", oDataSet, "tablausuarios.nombre");
                    campoApellido.DataBindings.Add("text", oDataSet, "tablausuarios.apellidos");
                    campoNivel.DataBindings.Add("text", oDataSet, "tablausuarios.codigonivel");
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablausuarios.condicion");
                    campoFecha.DataBindings.Add("text", oDataSet, "tablausuarios.fecharegistro");
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
        //Método para consultar usuario
        public Boolean consultarUsuario2(String login, System.Windows.Forms.TextBox campoPassword, System.Windows.Forms.TextBox campoId,
        System.Windows.Forms.TextBox campoNombre, System.Windows.Forms.TextBox campoApellido, System.Windows.Forms.TextBox campoNivel,
        System.Windows.Forms.ComboBox campoCondicion, System.Windows.Forms.TextBox campoFecha)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoPassword.DataBindings.Add("text", oDataSet, "tablausuarios.password");
                    campoId.DataBindings.Add("text", oDataSet, "tablausuarios.identificacion");
                    campoNombre.DataBindings.Add("text", oDataSet, "tablausuarios.nombre");
                    campoApellido.DataBindings.Add("text", oDataSet, "tablausuarios.apellidos");
                    campoNivel.DataBindings.Add("text", oDataSet, "tablausuarios.codigonivel");
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablausuarios.condicion");
                    campoFecha.DataBindings.Add("text", oDataSet, "tablausuarios.fecharegistro");
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
        //Método para consultar usuario
        public Boolean consultarUsuario3(String login, System.Windows.Forms.TextBox campoId,System.Windows.Forms.TextBox campoNombre, 
        System.Windows.Forms.TextBox campoApellido, System.Windows.Forms.TextBox campoNivel,System.Windows.Forms.TextBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoId.DataBindings.Add("text", oDataSet, "tablausuarios.identificacion");
                    campoNombre.DataBindings.Add("text", oDataSet, "tablausuarios.nombre");
                    campoApellido.DataBindings.Add("text", oDataSet, "tablausuarios.apellidos");
                    campoNivel.DataBindings.Add("text", oDataSet, "tablausuarios.codigonivel");
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablausuarios.condicion");
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
        //Método que muestra la condición de un usuario en un comboBox
        public Boolean mostrarCondicionUsuario(String login, System.Windows.Forms.ComboBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablausuarios.condicion");
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
        //Método que muestra la condición de un usuario en un comboBox
        public Boolean mostrarCondicionUsuario2(String login, System.Windows.Forms.TextBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablausuarios.condicion");
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
        //Método que muestra la condición de un usuario en un comboBox
        public Boolean mostrarCondicionNivel(String login, System.Windows.Forms.TextBox campoNivel)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNivel.DataBindings.Add("text", oDataSet, "tablausuarios.codigonivel");
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
        //Método para modificar la condición de un usuario
        public Boolean modificarCondicion(String login, String condicion)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLAUSUARIOS SET CONDICION = '" + condicion + "'" +
            "WHERE LOGINUSUARIO = '" + login + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0) return true;
            else return false;
        }
        //Método para modificar datos de un usuario
        public Boolean modificarDatosUsuario(String login, String id, String nombre, String apellido,String password, String codnivel, 
        String condicion)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLAUSUARIOS SET IDENTIFICACION = '" + id + "'," +
            "NOMBRE = '" + nombre + "',APELLIDOS = '" + apellido + "',PASSWORD = '" + password + "', " +
            "CODIGONIVEL = '" + codnivel + "' WHERE LOGINUSUARIO = '" + login + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0)
                return true;
            else
                return false;
        }
        //Método que permite eliminar a un usuario
        public void eliminarUsuario(String login)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina = new SqlCommand("DELETE FROM TABLAUSUARIOS WHERE LOGINUSUARIO = '" + login + "'", oConexion);
                //instruccion que borra un cliente por medio de la identificacion
                oDataAdapter.SelectCommand = oCmdElimina;
                //aqui se ejecuta el comando de la instruccion SQl
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablausuarios");
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
