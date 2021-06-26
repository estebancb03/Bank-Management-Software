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
    class conexionBaseDatos
    {
        //Define y construye la variable oConexion para Conexión con la BD utilizando
        //la cadena de conexión correspondiente

        #region

        //String de mi compu: "Data Source=DESKTOP-GF0GCJC;Initial Catalog=Creditos;Integrated Security=True"
        //String U: "Data Source=LAB1-SOTFWARE05\\SQLEXPRESS;Initial Catalog=Creditos;Integrated Security=True"

        #endregion

        public SqlConnection oConexion = new SqlConnection("Data Source=DESKTOP-I70AOMM;Initial Catalog=Creditos;Integrated Security=True");

        //Procedimiento que permite hacer conexión con la BD
        public void conectarbase()
        {
            try
            {
                oConexion.Open(); //Abre la conexión con la BD
                Console.WriteLine("Conectado..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //El WriteLine escribe una línea en la consola de salida
            }
            finally
            {
                //Aquí pregunta si el estado de la conexión está abierta
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
            //oConexion.Close();
        }
    }
}
