using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DDC_QC.Shared.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAuditArticleDefController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblAuditArticleDefController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/TblAuditArticleDefs
        [HttpGet]
        public async Task<ActionResult<TblAuditArticleDef>> GetTblAuditArticleDefs()
        {
            return Ok(await database.TblAuditArticleDef.ToListAsync());
        }

        // GET: api/TblAuditArticleDefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAuditArticleDef>> GetTblAuditArticleDef(int id)
        {
            var tblAuditArticleDef = await database.TblAuditArticleDef.FindAsync(id);

            if (tblAuditArticleDef == null)
            {
                return NotFound();
            }

            return tblAuditArticleDef;
        }

        // PUT: api/TblAuditArticleDefs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuditArticleDef(int id, TblAuditArticleDef tblAuditArticleDef)
        {
            if (id != tblAuditArticleDef.AuditArticleDefUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditArticleDef).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditArticleDefExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblAuditArticleDefs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAuditArticleDef>> PostTblAuditArticleDef(TblAuditArticleDef tblAuditArticleDef)
        {
            database.TblAuditArticleDef.Add(tblAuditArticleDef);
            await database.SaveChangesAsync();

            return CreatedAtAction("GetTblAuditArticleDef", new { id = tblAuditArticleDef.AuditArticleDefUid }, tblAuditArticleDef);
        }

        // DELETE: api/TblAuditArticleDefs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuditArticleDef>> DeleteTblAuditArticleDef(int id)
        {
            var tblAuditArticleDef = await database.TblAuditArticleDef.FindAsync(id);
            if (tblAuditArticleDef == null)
            {
                return NotFound();
            }

            database.TblAuditArticleDef.Remove(tblAuditArticleDef);
            await database.SaveChangesAsync();

            return tblAuditArticleDef;
        }

        private bool TblAuditArticleDefExists(int id)
        {
            return database.TblAuditArticleDef.Any(e => e.AuditArticleDefUid == id);
        }
    }
}