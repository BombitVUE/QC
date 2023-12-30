using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DDC_QC.Shared.Models;
using System.Linq.Expressions;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAuditDataController : ControllerBase
    {

        private readonly DIQCContext database;

        public TblAuditDataController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/TblAuditData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAuditData>>> GetTblAuditData()
        {
            return await database.TblAuditData.ToListAsync();
        }

        // GET: api/TblAuditData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAuditData>> GetTblAuditData(int id)
        {
            var tblAuditData = await database.TblAuditData.FindAsync(id);

            if (tblAuditData == null)
            {
                return NotFound();
            }

            return tblAuditData;
        }

        // PUT: api/TblAuditData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuditData(int id, TblAuditData tblAuditData)
        {
            if (id != tblAuditData.AuditDataUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditData).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditDataExists(id))
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

        // POST: api/TblAuditData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAuditData>> PostTblAuditData([FromBody] TblAuditData tblAuditData)
        {
            database.TblAuditData.Add(tblAuditData);
            _ = await database.SaveChangesAsync();

            return CreatedAtAction("GetTblAuditData", new { id = tblAuditData.AuditDataUid }, tblAuditData);
        }

        // DELETE: api/TblAuditData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuditData>> DeleteTblAuditData(int id)
        {
            var tblAuditData = await database.TblAuditData.FindAsync(id);
            if (tblAuditData == null)
            {
                return NotFound();
            }

            database.TblAuditData.Remove(tblAuditData);
            await database.SaveChangesAsync();

            return tblAuditData;
        }

        private bool TblAuditDataExists(int id)
        {
            return database.TblAuditData.Any(e => e.AuditDataUid == id);
        }
    }
}