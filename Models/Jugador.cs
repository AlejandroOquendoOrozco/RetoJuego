using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Jugador
    {

        #region Atributos
        public string Error { set; get; }
        public String Codigo { set; get; }
        [Required (ErrorMessage ="El nombre es un campo obligatorio")]
       public string Nombre { set; get; }
        [Required(ErrorMessage = "El correo es un campo obligatorio")]
        public string Correo { set; get; }
        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        public string Contraseña { set; get; }
        [Required(ErrorMessage = "Escribir la contraseña de nuevo es obligatorio")]
        public string ValidarContraseña { set; get; }

        public string Query { set; get; }

        #endregion
        #region Instancias Globales

         SqlCommand oComando=new SqlCommand();
         Conexion oConexion =new Conexion();
        #endregion
        #region Metodos
        public Jugador()
        {
            Codigo = null;
            Nombre = null;
            Correo = null;
            Contraseña = null;
            ValidarContraseña = null;
            Query = null;
           
        }

        //ESTE METODO NOS GENERA EL CODIGO DEL USUARIO
        public void GenerarCodigo()
        {
           
            Random codigo = new Random();
            Codigo = "" + codigo.Next(100000, 10000000);
        }
        //ESTE METODO NOS AGRAGA UN NUEVO JUGADOR
        public Boolean AgregarJugador()
        {

            Query = "INSERT INTO JUGADOR(CODIGO,NOMBRE,CORREO,CONTRASEÑA)VALUES(@CODIGO,@NOMBRE,@CORREO,@CONTRASEÑA)";
            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CODIGO", Codigo);
                oComando.Parameters.AddWithValue("@NOMBRE", Nombre);
                oComando.Parameters.AddWithValue("@CORREO", Correo);
                oComando.Parameters.AddWithValue("@CONTRASEÑA", Contraseña);
                oComando.ExecuteNonQuery();
                oConexion.CerrarConexion();
                return true;


            }
            catch(Exception e)
            {
                Error = e.ToString();
                oConexion.CerrarConexion();
                return false;
            }


        }
        public Boolean BuscarJugador()
        {

            Query = "SELECT CODIGO,NOMBRE,CONTRASEÑA FROM JUGADOR WHERE CORREO=@CORREO";
            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CORREO", Correo);
                SqlDataReader oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    Codigo = oReader["CODIGO"].ToString();
                    Nombre = oReader["NOMBRE"].ToString();
                    ValidarContraseña = oReader["CONTRASEÑA"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
               

            }
            catch (Exception e)
            {
                Error = e.ToString();
                return false;
            }


        }

        #endregion
    }
}
