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
    public class TblMatlGrpDefController : ControllerBase
    {
        private readonly DIQCContext database;

        public TblMatlGrpDefController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<TblMatlGrpDefController>
        [HttpGet]
        public async Task<IActionResult> GetTblMatlGrpDefs()
        {
            return Ok(await database.TblMatlGrpDef.ToListAsync());
        }

        // GET api/<TblMatlGrpDefController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMatlGrpDef>> GetTblMatlGrpDef(int id)
        {
            var tblMatlGrpDef = await database.TblMatlGrpDef.FindAsync(id);

            if (tblMatlGrpDef == null)
            {
                return NotFound();
            }

            return tblMatlGrpDef;
        }

        // POST api/<TblMatlGrpDefController>
        [HttpPost]
        public async Task<ActionResult<TblMatlGrpDef>> PostTblAuditScenario(TblMatlGrpDef tblMatlGrpDef)
        {

            try
            {

                if (tblMatlGrpDef == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblMatlGrpDef.Add(tblMatlGrpDef);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblMatlGrpDef", new { id = tblMatlGrpDef.MatlGrpDefUid }, tblMatlGrpDef);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TblMatlGrpDefController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMatlGrpDef (int id, TblMatlGrpDef tblMatlGrpDef)
        {
            if (id != tblMatlGrpDef.MatlGrpDefUid)
            {
                return BadRequest();
            }

            database.Entry(tblMatlGrpDef).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMatlGrpDefExists(id))
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

        // DELETE api/<TblMatlGrpDefController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblMatlGrpDef>> DeleteTblMatlGrpDef(int id)
        {

            try
            {
                var tblMatlGrpDef = await database.TblMatlGrpDef.FindAsync(id);

                if (tblMatlGrpDef == null)
                {
                    return NotFound();
                }

                database.TblMatlGrpDef.Remove(tblMatlGrpDef);
                await database.SaveChangesAsync();

                return tblMatlGrpDef;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        private bool TblMatlGrpDefExists(int id)
        {
            return database.TblMatlGrpDef.Any(e => e.MatlGrpDefUid == id);
        }
    }
}
