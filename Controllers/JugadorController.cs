using JuegoPreguntas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoPreguntas.Controllers
{
    
    public class JugadorController : Controller
    {
        //CARGA UNA VISTA
        public ActionResult Registro()
        {
            return View();
        }
        //CARGA UNA VISTA
        public ActionResult IniciarSesion()
        {
            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JugadorController1/Create
        public ActionResult Create()
        {
            return View();
        }
        //ESTE METODO VALIDA QUE LOS CAMPOS ESTEN BIEN PARA EL REGISTRO
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ValidarJugador(Jugador jugador)
        {
            if (TryValidateModel(jugador))
            {
                if (jugador.Contraseña.Equals(jugador.ValidarContraseña))
                {
                    jugador.GenerarCodigo();
                    if (jugador.AgregarJugador())
                    {
                        ViewData["MessajeJugador"] = "Registro Exitoso";
                        return View("IniciarSesion");
                        
                    }
                    else
                    {
                        ViewData["MessajeJugador"] = jugador.Error;
                    }
                }
                else
                {
                    ViewData["MessajeJugador"] = "Las contraseñas no coinciden";
                }
            }
            else
            {
                ViewData["MessajeJugador"] = "Por favor llene todos los campos";
            }


            return View("Registro");
        }
        //ESTE METODO VALIDA QUE EL JUGADOR ESTE REGISTRADO PARA PODER INICIAR SESION
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Entrar(Jugador jugador)
        {

            if (jugador.BuscarJugador())
            {
                ViewData["MessajeJugador"] = "Bienvendio " + jugador.Nombre.ToUpper() + " Estas listo para ganar";
                TempData["codigo"] = jugador.Codigo;
                return RedirectToAction("Panelinicio","Juego");
            }
            else
            {
                ViewData["MessajeJugador"] = "Lo sentimos el usuario no se encuentra Revise sus datos  intentelo nuevamente";
                return View("IniciarSesion");
            }
        
    
          
            
        }
    }
}
