using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prueba_de_Api.BD
{
    public class ConexionBd
    {
        private  string cadenaConexion = "";


        public ConexionBd() {

            this.cadenaConexion = "Integrated Security=SSPI;Persist Security Info=False;User ID=matias;Initial Catalog=webApiEmpresa;Data Source=DESKTOP-M6BU4CP";

        }

        public SqlConnection crearConexion() {


            SqlConnection con = new SqlConnection(this.cadenaConexion);
            try
            {
                con.Open();

                return con;
            }
            catch (Exception ex) {

                Console.WriteLine("ERROR en la Conexion de BD: "+ex.Message);

                return null;

            }

        }

    }
}