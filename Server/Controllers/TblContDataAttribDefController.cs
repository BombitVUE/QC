using DDC_QC.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblContDataAttribDefController : ControllerBase
    {
        private readonly DIQCContext database;

        public TblContDataAttribDefController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/<TblContDataAttribDefController>
        [HttpGet]
        public async Task<IActionResult> GetTblContDataAttribDefs()
        {
            return Ok(await database.TblContDataAttribDef.ToListAsync());
        }

        // GET api/<TblContDataAttribDefController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblContDataAttribDef>> GetTblContDataAttribDef(int id)
        {
            var tblContDataAttribDef = await database.TblContDataAttribDef.FindAsync(id);

            if (tblContDataAttribDef == null)
            {
                return NotFound();
            }

            return tblContDataAttribDef;
        }

        // POST api/<TblContDataAttribDefController>
        [HttpPost]
        public async Task<ActionResult<TblContDataAttribDef>> PostTblContDataAttribDef(TblContDataAttribDef tblContDataAttribDef)
        {

            try
            {

                if (tblContDataAttribDef == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblContDataAttribDef.Add(tblContDataAttribDef);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblContDataAttribDef", new { id = tblContDataAttribDef.ContDataAttribDefUid }, tblContDataAttribDef);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TblContDataAttribDefController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblContDataAttribDef(int id, TblContDataAttribDef tblContDataAttribDef)
        {
            if (id != tblContDataAttribDef.ContDataAttribDefUid)
            {
                return BadRequest();
            }

            database.Entry(tblContDataAttribDef).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContDataAttribDefExists(id))
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

        // DELETE api/<TblContDataAttribDefController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblContDataAttribDef>> DeleteTblContDataAttribDef(int id)
        {

            try
            {
                var tblContDataAttribDef = await database.TblContDataAttribDef.FindAsync(id);

                if (tblContDataAttribDef == null)
                {
                    return NotFound();
                }

                database.TblContDataAttribDef.Remove(tblContDataAttribDef);
                await database.SaveChangesAsync();

                return tblContDataAttribDef;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool TblContDataAttribDefExists(int id)
        {
            return database.TblContDataAttribDef.Any(e => e.ContDataAttribDefUid == id);
        }
    }
}
