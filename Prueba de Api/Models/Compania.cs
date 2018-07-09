using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Prueba_de_Api.Models
{
    public class Compania
    {

        public int id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        [Display(Name = "Nombre de Compañía")]
        [StringLength(100,ErrorMessage ="Solo puede tener 100 Caracteres")]
        public string nombre {get;set;}

        [Required(ErrorMessage ="La url es Requerida")]
        [Display(Name = "Url de la Compañia")]
        [StringLength (200, ErrorMessage ="Solo puede Tener 200 caracteres")]
        [DataType(DataType.Url)]
        public string url { get; set; }


        public List<Compania> allCompania() {

            // url para obtener los datos desde la api
            string stringUrlRequest = "http://localhost:7010/api/compania";

            // estraigo los datos en una varia tipo var
            var json = new WebClient().DownloadString(stringUrlRequest);

            // formater los datos al serializarlos
            JavaScriptSerializer ser = new JavaScriptSerializer();

            var list = JsonConvert.DeserializeObject<List<Compania>>(json);

            return list;
                 
        }


        public Boolean crearCompania(Compania compania) {

            BD.ConexionBd bd = new BD.ConexionBd();

            SqlConnection con = bd.crearConexion();

            SqlCommand command = new SqlCommand("createcompany",con);

            try
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

             
                command.Parameters.AddWithValue("name", compania.nombre);
                command.Parameters.AddWithValue("url", compania.url);

                command.ExecuteNonQuery();

              




                con.Close();
                return true;

            }

            catch (Exception ex) {

                Console.WriteLine("Error en la insercion de datos de Compania: "+ex.Message);
                con.Close();
                return false;

            }

        }

    }
}