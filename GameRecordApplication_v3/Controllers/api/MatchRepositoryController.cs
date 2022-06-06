using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GameRecordApplication_v3.DataAccessLayer;
using GameRecordApplication_v3.Models;

namespace GameRecordApplication_v3.Controllers.api
{
    public class MatchRepositoryController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/MatchRepository
        public async Task<IEnumerable<BilliardMatch>> GetBilliardMatches()
        {
            return await db.BilliardMatches.ToListAsync();
        }

        // GET: api/MatchRepository/5
        [ResponseType(typeof(BilliardMatch))]
        public IHttpActionResult GetBilliardMatch(long id)
        {
            BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            if (billiardMatch == null)
            {
                return NotFound();
            }

            return Ok(billiardMatch);
        }

        // PUT: api/MatchRepository/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBilliardMatch(long id, BilliardMatch billiardMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billiardMatch.BilliardMatchId)
            {
                return BadRequest();
            }

            db.Entry(billiardMatch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilliardMatchExists(id))
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

        // POST: api/MatchRepository
        [ResponseType(typeof(BilliardMatch))]
        public async Task<IHttpActionResult> PostBilliardMatch(BilliardMatch billiardMatch)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.BilliardMatches.Add(billiardMatch);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }

        // DELETE: api/MatchRepository/5
        [ResponseType(typeof(BilliardMatch))]
        public IHttpActionResult DeleteBilliardMatch(long id)
        {
            BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            if (billiardMatch == null)
            {
                return NotFound();
            }

            db.BilliardMatches.Remove(billiardMatch);
            db.SaveChanges();

            return Ok(billiardMatch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BilliardMatchExists(long id)
        {
            return db.BilliardMatches.Count(e => e.BilliardMatchId == id) > 0;
        }
    }
}