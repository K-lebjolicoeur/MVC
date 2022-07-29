using MVCyEF.datos;
using MVCyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCyEF.Controllers
{
    public class UsuarioController : Controller
    {
        //crear un vinculo controlador y datos, la entidad admin lo voy a usar para llamar datos
        UsuarioAdmin admin = new UsuarioAdmin();
        // GET: Usuario
        public ActionResult Index()
        {
           
            IEnumerable<usuario> lista = admin.Consultar();
            ViewBag.llamada = "";
            return View(lista);
        }
        public ActionResult Guardar()
        {
            ViewBag.llamada = "";
            return View();
        }
        public ActionResult nuevo(usuario usuario)
        {
            admin.Guardar(usuario);
            ViewBag.llamada = "Vehiculo guardado";
            return View("Guardar", usuario);
        }
        public ActionResult detalles(int id = 0)
        {
            usuario modelo = admin.Consultar(id);
            return View(modelo);
        }
        // la modificacion y guardar son casi lo mismo.
        public ActionResult Modificar(int id = 0)
        {
            usuario modelo = admin.Consultar(id);
            ViewBag.llamada = "";
            return View(modelo);
        }
        public ActionResult Actualizar(usuario usuario)
        {
            admin.Modificar(usuario);
            ViewBag.llamada = "Vehiculo Modificado";
            return View("Modificar", usuario);
        }
        public ActionResult Eliminar( int id = 0)
        {
            usuario usuario = new usuario()
            {
                Id = id
            };
            admin.Eliminar(usuario);
            ViewBag.llamada = "Vehiculo Eliminado";
            IEnumerable<usuario> lista = admin.Consultar();
            return View("Index", lista);
        }
    }
}