using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DDC_QC.Shared.Models;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAuditListsDefController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblAuditListsDefController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<tblAuditListsDefController>
        [HttpGet]
        public async Task<ActionResult<TblAuditListsDef>> GetTblAuditListsDefs()
        {
            return Ok(await database.TblAuditListsDef.ToListAsync());
        }

        // GET api/<tblAuditListsDefController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAuditListsDef>> GetTblAuditListsDef(int id)
        {
            var tblAuditListsDef = await database.TblAuditListsDef.FindAsync(id);

            if (tblAuditListsDef == null)
            {
                return NotFound();
            }

            return tblAuditListsDef;
        }

        // PUT api/<tblAuditListsDefController>/5
        [HttpPut("{id}")]
       

        public async Task<IActionResult> PutTblAuditListsDef(int id, TblAuditListsDef tblAuditListsDef)
        {
            if (id != tblAuditListsDef.AuditListsUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditListsDef).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditListsDefExists(id))
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

        // POST api/<tblAuditListsDefController>
        [HttpPost]
        public async Task<ActionResult<TblAuditListsDef>> PostTblAuditListsDef(TblAuditListsDef tblAuditListsDef)
        {

            try
            {

                if (tblAuditListsDef == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblAuditListsDef.Add(tblAuditListsDef);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblAuditListsDef", new { id = tblAuditListsDef.AuditListsUid}, tblAuditListsDef);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/TblAuditListsDefs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuditListsDef>> DeleteTblAuditListsDef(int id)
        {
            try
            {
                var tblAuditListsDef = await database.TblAuditListsDef.FindAsync(id);
                if (tblAuditListsDef == null)
                {
                    return NotFound();
                }

                database.TblAuditListsDef.Remove(tblAuditListsDef);
                await database.SaveChangesAsync();

                return tblAuditListsDef;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private bool TblAuditListsDefExists(int id)
        {
            return database.TblAuditListsDef.Any(e => e.AuditListsUid == id);
        }
    }
}