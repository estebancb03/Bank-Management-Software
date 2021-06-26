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
    class modeloNiveles
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
        public Boolean buscarCodigo(String codigo)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLANIVELES WHERE CODIGONIVEL = '" + codigo + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "Tablaniveles");
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
        //Método para buscar un login en la base de datos
        public Boolean buscarFuncion(String codigo)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAFUNCIONES WHERE CODIGOFUNCION = '" + codigo + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "Tablafuncion");
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
        //Método para buscar un login en la base de datos
        public Boolean buscarRol(String codigo)
        {
            Boolean enco = false;
            try
            {
                cn.conectarbase();
                //Construye oCmdConsulta con la instrucción en SQL para que busque
                //la identificación en la tabla
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES WHERE CODIGOROL = '" + codigo + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrucción SQL que está en oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet por si un caso tiene datos
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "Tablaroles");
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
        //Método para ingresar nivel
        public void ingresarNivel(String codigo, String nombre)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO TABLANIVELES (CODIGONIVEL,NOMBRENIVEL) VALUES (@codigo,@nombre)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));

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
        //Método para ingresar función
        public void ingresarFuncion(String codigo, String nombre)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO TABLAFUNCIONES (CODIGOFUNCION,NOMBREFUNCION) VALUES (@codigo,@nombre)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));

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
        //Método para ingresar rol
        public void ingresarRol(String codigoR, String codigoN, String codigoF, String condicion)
        {
            try
            {
                cn.conectarbase();
                //Construye oCmdInsercion con la instrucción en SQL para que busque la identificación en la tabla
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO TABLAROLES (CODIGOROL,CODIGONIVEL,CODIGOFUNCION,CONDICION) " +
                "VALUES (@codigor,@codigon,@codigof,@condicion)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Ejecuta la instrucción SQL que está en oCmdInserción

                //Aquí indicamos o especificamos el tipo de cada asociado a cada uno de los parámetros
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codigor", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codigon", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@codigof", SqlDbType.VarChar));
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
        //Método para cargar combo
        public void cargarComboNiveles(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLANIVELES ORDER BY CODIGONIVEL", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["nombrenivel"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Método para cargar combo
        public void cargarComboFunciones(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAFUNCIONES ORDER BY CODIGOFUNCION", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["nombrefuncion"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Método para cargar combo
        public void cargarComboRoles(System.Windows.Forms.ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES ORDER BY CODIGOROL", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega los elementos (identificacion) al combo
                    combo.Items.Add(dr["codigorol"]).ToString();
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        public Boolean mostrarCodigo(String nom, System.Windows.Forms.TextBox campoCodigo)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLANIVELES WHERE NOMBRENIVEL = '" + nom + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaniveles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCodigo.DataBindings.Add("text", oDataSet, "tablaniveles.codigonivel");
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
        public Boolean mostrarCodigoFuncion(String nom, System.Windows.Forms.ComboBox campoCodigo)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAFUNCIONES WHERE NOMBREFUNCION = '" + nom + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablafunciones");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCodigo.DataBindings.Add("text", oDataSet, "tablafunciones.codigofuncion");
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
        public Boolean mostrarNombre(String cod, System.Windows.Forms.ComboBox campoNombre)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLANIVELES WHERE CODIGONIVEL = '" + cod + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaniveles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNombre.DataBindings.Add("text", oDataSet, "tablaniveles.nombrenivel");
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
        public Boolean mostrarNombre2(String cod, System.Windows.Forms.TextBox campoNombre)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLANIVELES WHERE CODIGONIVEL = '" + cod + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaniveles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNombre.DataBindings.Add("text", oDataSet, "tablaniveles.nombrenivel");
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
        public Boolean mostrarNombreFuncion(String cod, System.Windows.Forms.TextBox campoNombre)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAFUNCIONES WHERE CODIGOFUNCION = '" + cod + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablafunciones");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNombre.DataBindings.Add("text", oDataSet, "tablafunciones.nombrefuncion");
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
        public Boolean mostrarNivel(String rol, System.Windows.Forms.TextBox campoNivel)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES WHERE CODIGOROL = '" + rol + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaroles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoNivel.DataBindings.Add("text", oDataSet, "tablaroles.codigonivel");
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
        public Boolean mostrarFuncion(String rol, System.Windows.Forms.TextBox campoFuncion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES WHERE CODIGOROL = '" + rol + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaroles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoFuncion.DataBindings.Add("text", oDataSet, "tablaroles.codigofuncion");
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
        public Boolean mostrarCondicionRol(String rol, System.Windows.Forms.ComboBox campoCondicion)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM TABLAROLES WHERE CODIGOROL = '" + rol + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta; //ejecuta instrucción de SQL
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "tablaroles");
                oConexion.Close();
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    /*Se agregan a los campos textos que son los parámetros, cada uno de los campos de la tabla que se 
                    van a mostrar en los campos textos a la hora de consultar los datos en el Form*/
                    campoCondicion.DataBindings.Add("text", oDataSet, "tablaroles.condicion");
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
        //Método que permite modificar los datos de un rol
        public Boolean modificarRol(String cod, String condicion)
        {
            oConexion.Open();
            SqlCommand oCmdModificar = new SqlCommand("UPDATE TABLAROLES SET CONDICION = '" + condicion + "' WHERE CODIGOROL = '" + cod + "'", oConexion);
            int i = oCmdModificar.ExecuteNonQuery();
            //Aquí ejecuta la sentencia UPDATE que está en el comando oCmdModificar
            oConexion.Close();
            if (i > 0)
                return true;
            else
                return false;
        }
    }
}
