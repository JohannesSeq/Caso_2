using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caso__2App.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult ListarProductos()
        {
            return View();
        }

        // GET: Productos/Editar/5
        public ActionResult Editar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // GET: Productos/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // GET: Productos/Crear
        public ActionResult Crear() => View();
    }
}