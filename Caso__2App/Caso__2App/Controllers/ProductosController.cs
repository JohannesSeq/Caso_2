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
    }
}