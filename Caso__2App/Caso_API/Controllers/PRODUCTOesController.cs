using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Caso_API.Controllers
{
    [RoutePrefix("api/producto")]
    public class PRODUCTOesController : ApiController
    {
        private CASO_PRACTICO_2Entities db = new CASO_PRACTICO_2Entities();

        // GET: api/producto/obtenertodos
        [HttpGet]
        [Route("obtenertodos")]
        public IEnumerable<PRODUCTO> GetTodos()
        {
            return db.PRODUCTO.ToList();
        }

        // GET: api/producto/obtenerid/5
        [HttpGet]
        [Route("obtenerid/{id:int}")]
        public IHttpActionResult GetPorId(int id)
        {
            var producto = db.PRODUCTO.Find(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/producto/crearproducto
        [HttpPost]
        [Route("crearproducto")]
        public IHttpActionResult Crear([FromBody] PRODUCTO producto)
        {
            if (producto == null)
                return BadRequest("Datos inválidos.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.PRODUCTO.Add(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        // PUT: api/producto/actualizarproducto/5
        [HttpPut]
        [Route("actualizarproducto/{id:int}")]
        public IHttpActionResult Actualizar(int id, [FromBody] PRODUCTO producto)
        {
            if (producto == null)
                return BadRequest("Datos inválidos.");

            var existente = db.PRODUCTO.Find(id);
            if (existente == null)
                return NotFound();

            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.Categoria = producto.Categoria;

            db.SaveChanges();
            return Ok(existente);
        }

        // DELETE: api/producto/eliminarproducto/5
        [HttpDelete]
        [Route("eliminarproducto/{id:int}")]
        public IHttpActionResult Eliminar(int id)
        {
            var producto = db.PRODUCTO.Find(id);
            if (producto == null)
                return NotFound();

            db.PRODUCTO.Remove(producto);
            db.SaveChanges();

            return Ok();
        }
    }
}
