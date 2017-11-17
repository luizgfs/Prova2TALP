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
    public class ProdutoesController : ApiController
    {
        private MinhaConexao db = new MinhaConexao();

        // GET: api/Produtoes
        /// <summary>
        /// obtem um produto
        /// </summary>
        /// <returns></returns>
        public IQueryable<Produto> GetProdutoes()
        {
            return db.Produtoes;
        }

        // GET: api/Produtoes/5
        /// <summary>
        /// obtem um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produtoes/5
        /// <summary>
        /// atualiza um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.id)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produtoes
        /// <summary>
        /// adiciona um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtoes.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.id }, produto);
        }

        // DELETE: api/Produtoes/5
        /// <summary>
        /// deleta um produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produtoes.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtoes.Count(e => e.id == id) > 0;
        }
    }
}