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

namespace DDC_QC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAuditScenarioController : ControllerBase
    {
        private readonly DIQCContext database;

        public TblAuditScenarioController(DIQCContext context)
        {
            database = context;
        }

        // GET: api/TblAuditScenarios
        [HttpGet]
        public async Task<IActionResult> GetTblAuditScenarios()
        {
            try
            {
                return Ok(JsonSerializer.Serialize(await database.TblAuditScenario.ToListAsync()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/TblAuditScenarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblAuditScenario([FromRoute] int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblAuditScenario = await database.TblAuditScenario.FindAsync(Id);

            if (tblAuditScenario == null)
            {
                return NotFound();
            }

            return Ok(tblAuditScenario);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetTblAuditData(int skip = 0, int take = 5, string orderBy = "AuditScenarioUid")
        //{
        //    try
        //    {
        //        var query = database.TblAuditData.AsQueryable();

        //        var orderByExpression = GetOrderByExpression(orderBy);

        //        var orderedQuery = query.OrderBy(orderByExpression);

        //        var pagedQuery = orderedQuery.Skip(skip).Take(take);

        //        var result = await pagedQuery.ToListAsync();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //private Expression<Func<TblAuditData, object>> GetOrderByExpression(string orderBy)
        //{
        //    switch (orderBy)
        //    {
        //        case "AuditDataUid":
        //            return x => x.AuditDataUid;
        //        case "AuditScenarioUid":
        //            return x => x.AuditScenarioUid;
        //        case "AuditArticleDefUid":
        //            return x => x.AuditArticleDefUid;
        //        case "Order":
        //            return x => x.Order;
        //        case "Deleted":
        //            return x => x.Deleted;
        //        case "RevDate":
        //            return x => x.RevDate;
        //        default:
        //            return x => x.AuditDataUid;
        //    }
        //}


        // POST: api/TblAuditScenarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAuditScenario>> PostTblAuditScenario(TblAuditScenario tblAuditScenario)
        {

            try
            {

                if (tblAuditScenario == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                database.TblAuditScenario.Add(tblAuditScenario);
                await database.SaveChangesAsync();

                return CreatedAtAction("GetTblAuditScenario", new { Id = tblAuditScenario.AuditScenarioUid }, tblAuditScenario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT: api/TblAuditScenarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuditScenario(int Id, TblAuditScenario tblAuditScenario)
        {
            if (Id != tblAuditScenario.AuditScenarioUid)
            {
                return BadRequest();
            }

            database.Entry(tblAuditScenario).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuditScenarioExists(Id))
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




        // DELETE: api/TblAuditScenarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuditScenario>> DeleteTblAuditScenario(int Id)
        {

            try
            {
                var tblAuditScenario = await database.TblAuditScenario.FindAsync(Id);

                if (tblAuditScenario == null)
                {
                    return NotFound();
                }

                database.TblAuditScenario.Remove(tblAuditScenario);
                await database.SaveChangesAsync();

                return tblAuditScenario;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool TblAuditScenarioExists(int Id)
        {
            return database.TblAuditScenario.Any(e => e.AuditScenarioUid == Id);
        }
    }
}