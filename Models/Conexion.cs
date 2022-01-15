using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Conexion
    {
        public string Error { set; get; }
        SqlConnection oConexion = new SqlConnection("Data Source=.;Initial Catalog=JUEGOPREGUNTAS;Integrated Security=True");

        //ESTE METODO ABRE LA CONEXION DE LA BASE DE DATOS
        public SqlConnection Conectar()
        {
            try
            {
                oConexion.Open();
                return oConexion;
            }catch(Exception e)
            {
                Error = e.ToString();
                return null;
            }
        }

        //ESTE METODO CIERRA LA CONEXION DE LA BASE DE DATOS
        public Boolean CerrarConexion()
        {
            try
            {
                oConexion.Close();
                return true;
            }
            catch (Exception e)
            {
                Error = e.ToString();
                return false;
            }
        }
    }
}
