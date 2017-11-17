using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_Prova.Connection;
using WebApi_Prova.Models;

namespace WebApi_Prova.Controllers
{
    public class ClientesController : ApiController
    {
        private MinhaConexao db = new MinhaConexao();

        // GET: api/Clientes
        /// <summary>
        /// obter cliente
        /// </summary>
        /// <returns>cliente</returns>
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        /// <summary>
        /// obter cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>cliente</returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        /// <summary>
        /// atualiza um cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        /// <summary>
        /// adiciona um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente.id }, cliente);
        }

        // DELETE: api/Clientes/5
        /// <summary>
        /// deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.id == id) > 0;
        }
    }
}