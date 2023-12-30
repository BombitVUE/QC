using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DDC_QC.Shared.Models;

namespace DDC_QC.Server.Pages
{
    public class AuditDataModel : PageModel
    {
        private readonly DIQCContext _context;

        public AuditDataModel(DIQCContext context)
        {
            _context = context;
        }

        public TblAuditData TblAuditData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblAuditData = await _context.TblAuditData.FirstOrDefaultAsync(m => m.AuditDataUid == id);

            if (TblAuditData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}