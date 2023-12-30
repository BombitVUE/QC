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
    public class TblAuditScenarioConnectionController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblAuditScenarioConnectionController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<TblAuditScenarioConnectionController>
        [HttpGet]
        public async Task<IActionResult> GetTblAuditScenarioConnections()
        {
            return Ok(await database.TblAuditScenarioConnection.ToListAsync());
        }

        // GET api/<TblAuditScenarioConnectionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblAuditScenarioConnection(int id)
        {
            var tblAuditScenarioConnection = await database.TblAuditScenarioConnection.FindAsync(id);

            if (tblAuditScenarioConnection == null)
            {
                return NotFound();
            }

            return Ok(tblAuditScenarioConnection);
        }


        // PUT api/<TblAuditScenarioConnectionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuditScenarioConnection(int id, TblAuditScenarioConnection tblAuditScenarioConnection)
        {
            if (id != tblAuditScenarioConnection.AuditScenarioConnectionUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditScenarioConnection).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditScenarioConnectionExists(id))
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
        // POST api/<TblAuditScenarioConnectionController>
        [HttpPost]
        public async Task<ActionResult<TblAuditScenarioConnection>> PostTblAuditScenarioConnection(TblAuditScenarioConnection tblAuditScenarioConnection)
        {

            try
            {

                if (tblAuditScenarioConnection == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblAuditScenarioConnection.Add(tblAuditScenarioConnection);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblAuditScenarioConnection", new { id = tblAuditScenarioConnection.AuditScenarioUid }, tblAuditScenarioConnection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<TblAuditScenarioConnectionController>/5
        public async Task<ActionResult<TblAuditScenarioConnection>> DeleteTblAuditScenarioConnection(int id)
        {

            try
            {
                var tblAuditScenarioConnection = await database.TblAuditScenarioConnection.FindAsync(id);

                if (tblAuditScenarioConnection == null)
                {
                    return NotFound();
                }

                database.TblAuditScenarioConnection.Remove(tblAuditScenarioConnection);
                await database.SaveChangesAsync();

                return tblAuditScenarioConnection;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        private bool TblAuditScenarioConnectionExists(int id)
        {
            return database.TblAuditScenarioConnection.Any(e => e.AuditScenarioConnectionUid == id);
        }
    }
}
