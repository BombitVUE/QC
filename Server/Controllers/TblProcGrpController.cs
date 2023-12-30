using DDC_QC.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblProcGrpController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblProcGrpController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<TblProcGrpController>
        [HttpGet]
        public async Task<IActionResult> GetTblProcGrps()
        {
            return Ok(await database.TblProcGrp.ToListAsync());
        }

        // GET api/<TblProcGrpController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProcGrp>> GetTblProcGrp(int id)
        {
            var tblProcGrp = await database.TblProcGrp.FindAsync(id);

            if (tblProcGrp == null)
            {
                return NotFound();
            }

            return tblProcGrp;
        }

        // POST api/<TblProcGrpController>
        [HttpPost]
        public async Task<ActionResult<TblProcGrp>> PostTblProcGrp (TblProcGrp tblProcGrp)
        {

            try
            {

                if (tblProcGrp == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblProcGrp.Add(tblProcGrp);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblProcGrp", new { id = tblProcGrp.ProcGrpUid }, tblProcGrp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TblProcGrpController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProcGrp(int id, TblProcGrp tblProcGrp)
        {
            if (id != tblProcGrp.ProcGrpUid)
            {
                return BadRequest("ProcGrp ID mismatch");
            }

            database.Entry(tblProcGrp).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProcGrpExists(id))
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

        // DELETE api/<TblProcGrpController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblProcGrp>> DeleteTblProcGrp(int id)
        {

            try
            {
                var tblProcGrp = await database.TblProcGrp.FindAsync(id);

                if (tblProcGrp == null)
                {
                    return NotFound();
                }

                database.TblProcGrp.Remove(tblProcGrp);
                await database.SaveChangesAsync();

                return tblProcGrp;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool tblProcGrpExists(int id)
        {
            return database.TblProcGrp.Any(e => e.ProcGrpUid == id);
        }
    }
}
