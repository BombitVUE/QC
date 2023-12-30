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
    public class TblContDataAttribDataController : ControllerBase
    {
        private readonly DIQCContext database;

        public TblContDataAttribDataController(DIQCContext context)
        {
            database = context;
        }
        // GET: api/<TblContDataAttribDataController>
        [HttpGet]
        public async Task<IActionResult> GetTblContDataAttribDatas()
        {
            return Ok(await database.TblContDataAttribData.ToListAsync());
        }

        // GET api/<TblContDataAttribDataController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblContDataAttribData>> GetTblContDataAttribData(int id)
        {
            var tblContDataAttribData = await database.TblContDataAttribData.FindAsync(id);

            if (tblContDataAttribData == null)
            {
                return NotFound();
            }

            return tblContDataAttribData;
        }

        // POST api/<TblContDataAttribDataController>
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<TblContDataAttribData>> PosTblContDataAttribData(TblContDataAttribData tblContDataAttribData)
        {

            try
            {

                if (tblContDataAttribData == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblContDataAttribData.Add(tblContDataAttribData);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblContDataAttribData", new { id = tblContDataAttribData.ContDataAttribDataUid }, tblContDataAttribData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<TblContDataAttribDataController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblContDataAttribData(int id, TblContDataAttribData tblContDataAttribData)
        {
            if (id != tblContDataAttribData.ContDataAttribDataUid)
            {
                return BadRequest();
            }

            database.Entry(tblContDataAttribData).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContDataAttribDataExists(id))
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

        // DELETE api/<TblContDataAttribDataController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblContDataAttribData>> DeleteTblContDataAttribData(int id)
        {

            try
            {
                var tblContDataAttribData = await database.TblContDataAttribData.FindAsync(id);

                if (tblContDataAttribData == null)
                {
                    return NotFound();
                }

                database.TblContDataAttribData.Remove(tblContDataAttribData);
                await database.SaveChangesAsync();

                return tblContDataAttribData;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool TblContDataAttribDataExists(int id)
        {
            return database.TblContDataAttribData.Any(e => e.ContDataAttribDataUid == id);
        }
    }
}
