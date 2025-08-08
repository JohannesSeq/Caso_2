using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        public IHttpActionResult GetAll()
        {
            var items = db.PRODUCTO.ToList(); // sin OrderBy por Id
            return Ok(items);
        }

        // GET: api/producto/obtenerid/5
        [HttpGet]
        [Route("obtenerid/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var p = db.PRODUCTO.Find(id); // usa la PK del EDMX
            if (p == null) return NotFound();
            return Ok(p);
        }

        // POST: api/producto/crearproducto
        [HttpPost]
        [Route("crearproducto")]
        public IHttpActionResult Create([FromBody] PRODUCTO producto)
        {
            if (producto == null) return BadRequest("Datos inválidos.");
            if (!ModelState.IsValid) return BadRequest("Modelo inválido.");

            try
            {
                db.PRODUCTO.Add(producto);
                db.SaveChanges();
                return Ok(producto);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ve in ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors))
                    ModelState.AddModelError(ve.PropertyName, ve.ErrorMessage);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/producto/actualizarproducto/5
        [HttpPut]
        [Route("actualizarproducto/{id:int}")]
        public IHttpActionResult Update(int id, [FromBody] PRODUCTO producto)
        {
            if (producto == null) return BadRequest("Datos inválidos.");
            if (!ModelState.IsValid) return BadRequest("Modelo inválido.");

            var existing = db.PRODUCTO.Find(id);
            if (existing == null) return NotFound();

            try
            {
                // mapea solo campos editables existentes en tu EDMX
                existing.Nombre = producto.Nombre;
                existing.Descripcion = producto.Descripcion;
                existing.Precio = producto.Precio;
                existing.Stock = producto.Stock;
                existing.Categoria = producto.Categoria;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(existing);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ve in ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors))
                    ModelState.AddModelError(ve.PropertyName, ve.ErrorMessage);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/producto/eliminarproducto/5
        [HttpDelete]
        [Route("eliminarproducto/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var existing = db.PRODUCTO.Find(id);
            if (existing == null) return NotFound();

            try
            {
                db.PRODUCTO.Remove(existing);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
