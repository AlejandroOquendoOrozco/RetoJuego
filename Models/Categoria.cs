using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Categoria:Ronda
    {

        #region Atributos
       
        public string NombreCategoria { set; get; }

        public string NivelCategoria { set; get; }
        #endregion
        #region Instancias globales
        SqlCommand oComando = new SqlCommand();
        Conexion oConexion = new Conexion();
        #endregion


        #region Metodos

        public Categoria()
        {
            
            NombreCategoria = null;
            NivelCategoria = null;
            
        }


        //ESTE METODO TRAE LAS CATEGORIAS CORRESPONDIENTES
        public Boolean CargarCategorias()
        {
         
            Query = "SELECT NOMBRECATEGORIA,NIVELCATEGORIA FROM CATEGORIA WHERE CODIGOCATEGORIA=@CODIGO";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CODIGO", CodigoCategoria);
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    NivelCategoria = oReader["NIVELCATEGORIA"].ToString();
                    NombreCategoria = oReader["NOMBRECATEGORIA"].ToString();

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
