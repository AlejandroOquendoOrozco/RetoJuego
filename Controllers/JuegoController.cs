using JuegoPreguntas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JuegoPreguntas.Controllers
{
    public class JuegoController : Controller
    {
        static int ContadorRondas=1;
        static string ContenedorPregunta = null;
        static string codigojugador;
        static List<Premio> premiosGanados = new List<Premio>();

       //CARGA UNA VISTA
        public ActionResult Panelinicio()
        {
            var codigojugador = TempData["codigo"];
            return View();
        }
        //CARGA UNA VISTA
        public ActionResult PanelContinuar()
        {
            return View();
        }
        //CARGA UNA VISTA
        public ActionResult PanelEliminado()
        {
            return View();
        }

        [HttpPost]
       
       
        public ActionResult Panelinfo(IFormCollection form)
        {
            if (ContenedorPregunta.Equals(form["opcion"]))
            {
               
                ContadorRondas = ContadorRondas + 1;
                ViewData["infopanel"] = "QUE QUIERES HACER VIKINGO";
                return View("PanelContinuar");
                
            }
            else
            {
                
                return View("PanelEliminado");
            }
           
        }
        public ActionResult PanelPreguntas()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult PanelGanador(int id)
        {
            return View();
        }

        //
        public ActionResult Create()
        {
            return View();
        }

        //ESTE METODO NOS CARGA TODAS LAS PREGUNTAS PREMIOS RESPUESTAS ETC.. DEL JUEGO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CargarJuego(Ronda ronda,Categoria categoria,Premio premio,Pregunta pregunta)
        {
            
            List<Pregunta> listpregunta;
            String[] Datos;


            if (ContadorRondas < 6)
            {
                ronda.NumeroRonda = ContadorRondas;
                if (ronda.CargarRondas())
                {
                    categoria.CodigoCategoria = ronda.CodigoCategoria;
                    premio.premioRonda = ronda.premioRonda;
                    if (categoria.CargarCategorias())
                    {
                        if (premio.CargarPremio())
                        {
                            ViewData["NumeroRonda"] = ronda.NumeroRonda;
                            ViewData["NombreCategoria"] = categoria.NombreCategoria;
                            ViewData["NivelCategoria"] = categoria.NivelCategoria;
                            ViewData["ValorPremio"] = premio.valorpremio;
                            ViewData["TipoPremio"] = premio.TipoPremio;
                            pregunta.CodigoCategoria = categoria.CodigoCategoria;
                            listpregunta = pregunta.CargarPreguntas();
                            if (listpregunta != null)
                            {
                                if (ContadorRondas == 1)
                                {
                                    Datos = BuscarPregunta(listpregunta, 1, 5);
                                    ViewData["Pregunta"] = Datos[0];
                                    pregunta.CodigoPregunta = Datos[1];
                                    AgregarPremio(premio.TipoPremio, premio.premioRonda, premio.valorpremio,ronda.NumeroRonda);
                                    
                                }
                                if (ContadorRondas == 2)
                                {
                                    
                                    Datos = BuscarPregunta(listpregunta, 6, 10);
                                    ViewData["Pregunta"] = Datos[0];
                                    pregunta.CodigoPregunta = Datos[1];
                                    AgregarPremio(premio.TipoPremio, premio.premioRonda, premio.valorpremio, ronda.NumeroRonda);
                                }
                                if (ContadorRondas == 3)
                                {
                                  
                                    Datos = BuscarPregunta(listpregunta, 11, 15);
                                    ViewData["Pregunta"] = Datos[0];
                                    pregunta.CodigoPregunta = Datos[1];
                                    AgregarPremio(premio.TipoPremio, premio.premioRonda, premio.valorpremio, ronda.NumeroRonda);

                                }
                                if (ContadorRondas == 4)
                                {
                                   
                                    Datos = BuscarPregunta(listpregunta, 16, 19);
                                    ViewData["Pregunta"] = Datos[0];
                                    pregunta.CodigoPregunta = Datos[1];
                                    AgregarPremio(premio.TipoPremio, premio.premioRonda, premio.valorpremio, ronda.NumeroRonda);

                                }
                                if (ContadorRondas == 5)
                                {
                                    
                                    Datos = BuscarPregunta(listpregunta, 20, 25);
                                    ViewData["Pregunta"] = Datos[0];
                                    pregunta.CodigoPregunta = Datos[1];
                                    AgregarPremio(premio.TipoPremio, premio.premioRonda, premio.valorpremio, ronda.NumeroRonda);
                                }
                                if (pregunta.CargarRepuestas())
                                {
                                    ViewData["opcion1"] = pregunta.RespuestaCorrecta;
                                    ViewData["opcion2"] = pregunta.RespuetaFalsa1;
                                    ViewData["opcion3"] = pregunta.Respuestafalsa2;
                                    ViewData["opcion4"] = pregunta.Respuestafalsa3;
                                    ContenedorPregunta = pregunta.RespuestaCorrecta;
                                }
                                else
                                {
                                    ViewData["Info"] = "Error rondas" + pregunta.Error;
                                }
                            }

                        }

                    }



                }
            }
            else
            {
                Retirarse();
                ViewData["MessajeGanador"] = "ERES EL GANADOR DE TODOS LOS PREMIOS VIKINGO,EN EL VALHALLA LOS DIOSES ESTAN BRINDANDO EN TU NOMBRE";
                return View("PanelGanador");
            }

            return View("PanelPreguntas");
        }
    
        //ESTE METODO GENERA LA PREGUNTA ALEATORIA 
       public string generarpreguntaaleatoria(int valor1,int valor2)
        {
            string cod;
            Random npregunta = new Random();
            cod = "" + npregunta.Next(valor1,valor2);
            return cod;

        }
        //ESTE METODO BUSCA LA PREGUNTA GENERADA ALEATORIAMENTE
        public String[] BuscarPregunta(List<Pregunta> list,int rango1,int rango2)
        {
          

            string[] Datos = new string[2];
            string CodPregunta=generarpreguntaaleatoria(rango1,rango2);
            foreach(var pregunta in list)
            {
                if (pregunta.CodigoPregunta.Equals(CodPregunta))
                {
                    Datos[0] = pregunta.TituloPregunta;
                    Datos[1] = pregunta.CodigoPregunta;
                    return Datos;
                }
            }

           return null; 
        }

        //ESTE METODO GUARDA LOS PREMIOS QUE EL JUGADOR VA GANANDO
        public void AgregarPremio(string valor,string tipo,string codigo,int ronda)
        {
            premiosGanados.Add(new Premio() { TipoPremio = tipo, premioRonda = codigo, valorpremio = valor,NumeroRonda=ronda });
        }
        public ActionResult Retirarse()
        {

            foreach (var premios in premiosGanados)
            {

                premios.AgregarPremiosJugador(codigojugador);
            }
            ViewBag.Premios= premiosGanados;
            ViewData["MessajeGanador"] = "TUS PREMIOS VIKINGO ES:";
            return View("PanelGanador");
        }
        //ESTE METODO ES PARA SALIR Y RESTAURAR A VALORES PREDETERMINADO
        public ActionResult Salir()
        {
            ContadorRondas = 1;
            ContenedorPregunta = null;
            
            codigojugador = null;
            return RedirectToAction("Index", "Home");
        }
        
    }
}
