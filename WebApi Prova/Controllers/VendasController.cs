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
    public class VendasController : ApiController
    {
        private MinhaConexao db = new MinhaConexao();

        // GET: api/Vendas
        /// <summary>
        /// obtem um venda
        /// </summary>
        /// <returns></returns>
        public IQueryable<Venda> GetVendas()
        {
            return db.Vendas;
        }

        // GET: api/Vendas/5
        /// <summary>
        /// obtem um venda pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Venda))]
        public IHttpActionResult GetVenda(int id)
        {
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        // PUT: api/Vendas/5
        /// <summary>
        /// atualiza uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="venda"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda(int id, Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda.id)
            {
                return BadRequest();
            }

            db.Entry(venda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Vendas
        /// <summary>
        /// adiciona uma venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        [ResponseType(typeof(Venda))]
        public IHttpActionResult PostVenda(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendas.Add(venda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = venda.id }, venda);
        }

        // DELETE: api/Vendas/5
        /// <summary>
        /// deleta uma venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Venda))]
        public IHttpActionResult DeleteVenda(int id)
        {
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return NotFound();
            }

            db.Vendas.Remove(venda);
            db.SaveChanges();

            return Ok(venda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendaExists(int id)
        {
            return db.Vendas.Count(e => e.id == id) > 0;
        }
    }
}