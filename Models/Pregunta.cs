using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Models
{
    public class Pregunta:Categoria
    {

        #region Atributos
        public string CodigoPregunta { set; get; }
        public string CodigoRespuesta { set; get; }
        public string TituloPregunta { set; get; }

        public string RespuestaCorrecta { set; get; }

        public string RespuetaFalsa1 { set; get; }

        public string Respuestafalsa2 { set; get; }

        public string Respuestafalsa3 { set; get; }

        public string Respuestavista { set; get; }
        #endregion
        #region Instancias globales
        SqlCommand oComando = new SqlCommand();
        Conexion oConexion = new Conexion();
        #endregion
        #region Metodos
        public Pregunta()
        {

            CodigoPregunta = null;
            CodigoRespuesta = null;
            TituloPregunta = null;
            RespuestaCorrecta = null;
            RespuetaFalsa1 = null;
            Respuestafalsa2 = null;
            Respuestafalsa3 = null;
        }
        //ESTE METODO NOS TRAE EN UNA LISTA LAS PREGUNTAS CORRESPONDIENTES PARA CADA RONDA
        public List<Pregunta> CargarPreguntas()
        {
            List<Pregunta> listPreguntas = new List<Pregunta>();
            Query = "SELECT CODIGOPREGUNTA,TITULOPREGUNTA FROM PREGUNTA WHERE CATEGORIA=@CATEGORIA";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CATEGORIA", CodigoCategoria);
                SqlDataReader oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    listPreguntas.Add(new Pregunta()
                    { CodigoPregunta = oReader["CODIGOPREGUNTA"].ToString(), TituloPregunta = oReader["TITULOPREGUNTA"].ToString() });
                }
                oConexion.CerrarConexion();
                return listPreguntas;
            }
            catch (Exception e)
            {

                Error = e.ToString();
                oConexion.CerrarConexion();
                return null;
            }
        }
        
        //ESTE METODO NOS TRAE LAS RESPUESTA DE CADA PREGUNTA
        public Boolean CargarRepuestas()
        {
            
            Query = "SELECT CODRESPUESTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3 FROM RESPUESTA WHERE CODPREGUNTA=@CODIGO";

            try
            {
                oComando.Connection = oConexion.Conectar();
                oComando.CommandText = Query;
                oComando.Parameters.AddWithValue("@CODIGO", CodigoPregunta);
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    CodigoRespuesta = oReader["CODRESPUESTA"].ToString();
                    RespuestaCorrecta = oReader["RESPUESTACORRECTA"].ToString();
                    RespuetaFalsa1 = oReader["RESPUESTAFALSA1"].ToString();
                    Respuestafalsa2 = oReader["RESPUESTAFALSA2"].ToString();
                    Respuestafalsa3 = oReader["RESPUESTAFALSA3"].ToString();
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
#endregion

    }

}
