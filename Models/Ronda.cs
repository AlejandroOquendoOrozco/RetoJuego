using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Ronda
    {

        #region Atributos

        public string Error { set; get; }
        public int NumeroRonda { set; get; }
        public string premioRonda { set; get; }

        public string CodigoCategoria { set; get; }
        public string Query { set; get; }
        #endregion
        #region Instancias globales
        SqlCommand oComando = new SqlCommand();
        Conexion oConexion = new Conexion();
        #endregion
        #region Metodos
        public Ronda()
        {
            NumeroRonda =-1;
            Query = null;
            CodigoCategoria = null;

        }
        //ESTE METODO NOS CARGA TODO LO RELACIONADO CON LA RONDA
        public Boolean CargarRondas()
        {

            Query = "SELECT PREMIORONDA,CODCATEGORIA FROM RONDA WHERE NUMERORONDA=@NUMERO";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@NUMERO", NumeroRonda);
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    premioRonda = oReader["PREMIORONDA"].ToString();
                    CodigoCategoria = oReader["CODCATEGORIA"].ToString();

                    oConexion.CerrarConexion();
                    
                    return true;
                }
                else
                {
                    oConexion.CerrarConexion();
                    return false;
                }

            }
            catch (Exception e)
            {
                oConexion.CerrarConexion();

                Error = e.ToString();
                return false;
            }
        }
        #endregion
    }
}

       

