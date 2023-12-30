using DDC_QC.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblContDataController : ControllerBase
    {
        private readonly DIQCContext database;

        public TblContDataController (DIQCContext context)
        {
            database = context;
        }
        // GET: api/<TblContDataController>
        [HttpGet]
        public async Task<IActionResult> GetTblContDatas()
        {
            return Ok(await database.TblContData.ToListAsync());
        }

        // GET api/<TblContDataController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblContData>> GetTblContData(int id)
        {
            var tblContData = await database.TblContData.FindAsync(id);

            if (tblContData == null)
            {
                return NotFound();
            }

            return tblContData;
        }
        
        // POST api/<TblContDataController>
        // POST: api/TblAuditScenarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblContData>> PostTblContData(TblContData tblContData)
        {

            try
            {

                if (tblContData == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblContData.Add(tblContData);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblAuditScenario", new { id = tblContData.ContTranUid }, tblContData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TblContDataController>/5
        public async Task<IActionResult> PutTblContData(int id, TblContData tblContData)
        {
            if (id != tblContData.ContTranUid)
            {
                return BadRequest();
            }

            database.Entry(tblContData).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContDataExists(id))
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

        // DELETE api/<TblContDataController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblContData>> DeleteTblContData(int id)
        {

            try
            {
                var tblContData = await database.TblContData.FindAsync(id);

                if (tblContData == null)
                {
                    return NotFound();
                }

                database.TblContData.Remove(tblContData);
                await database.SaveChangesAsync();

                return tblContData;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool TblContDataExists(int id)
        {
            return database.TblContData.Any(e => e.ContTranUid == id);
        }
    }
}
