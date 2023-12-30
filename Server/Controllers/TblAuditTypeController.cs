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
    public class TblAuditTypeController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblAuditTypeController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<TblAuditTypeController>
        [HttpGet]
        public async Task<IActionResult> GetTblAuditTypes()
        {
            return Ok(await database.TblAuditType.ToListAsync());
        }

        // GET api/<TblAuditTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAuditType>> GetTblAuditType(int id)
        {
            var tblAuditType = await database.TblAuditType.FindAsync(id);

            if (tblAuditType == null)
            {
                return NotFound();
            }

            return tblAuditType;
        }
        // POST api/<TblAuditTypeController>
        [HttpPost]
        public async Task<ActionResult<TblAuditType>> PostTblAuditType(TblAuditType tblAuditType)

        {
            try
            {

                if (tblAuditType == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblAuditType.Add(tblAuditType);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblAuditType", new { id = tblAuditType.AuditTypeUid }, tblAuditType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TblAuditTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuditType(int id, TblAuditType tblAuditType)
        {
            if (id != tblAuditType.AuditTypeUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditType).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditTypeExists(id))
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


        // DELETE api/<TblAuditTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuditType>> DeleteTblAuditType(int id)
        {

            try
            {
                var tblAuditType = await database.TblAuditType.FindAsync(id);

                if (tblAuditType == null)
                {
                    return NotFound();
                }

                database.TblAuditType.Remove(tblAuditType);
                await database.SaveChangesAsync();

                return tblAuditType;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool TblAuditTypeExists(int id)
        {
            return database.TblAuditType.Any(e => e.AuditTypeUid == id);
        }
    }
}