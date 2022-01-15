using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Premio:Ronda
    {
        #region Atributos
        public string TipoPremio { set; get; }
        public string valorpremio { set; get; }
        #endregion
        #region Instancias globales
        SqlCommand oComando = new SqlCommand();
        Conexion oConexion = new Conexion();
        #endregion
        #region Metodos
        public Premio()
        {
            premioRonda = null;
            TipoPremio = null;
            valorpremio = null;
        }

        //ESTE METODO NOS TRAE EL PREMIO A GANAR EN CADA RONDA
        public Boolean CargarPremio()
        {

            Query = "SELECT TIPOPREMIO,VALORPREMIO FROM PREMIO WHERE CODIGOPREMIO=@CODIGO";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CODIGO", premioRonda);
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    TipoPremio = oReader["TIPOPREMIO"].ToString();
                    valorpremio = oReader["VALORPREMIO"].ToString();
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

                Error = e.ToString();
                oConexion.CerrarConexion();
                return false;
            }
        }

        //ESTE METODO AGREGA LOS PREMIOS GANADOS POR EL JUGADOR
        public Boolean AgregarPremiosJugador(string Codigo)
        {
            Query = "INSERT INTO JUGADOR (CODIGORONDA) VALUES(@RONDA) WHERE CODIGO=@CODIGO)";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@RONDA", NumeroRonda);
                oComando.Parameters.AddWithValue("@CODIGO", Codigo);
                oComando.ExecuteNonQuery();

                oConexion.CerrarConexion();
                return true;

            }
            catch (Exception e)
            {

                Error = e.ToString();
                oConexion.CerrarConexion();
                return false;
            }
        }
        #endregion

    }
}
