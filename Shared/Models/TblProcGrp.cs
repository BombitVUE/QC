using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblProcGrp
    {
        public TblProcGrp()
        {
            TblMatlGrpDef = new HashSet<TblMatlGrpDef>();
        }

        public int ProcGrpUid { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual ICollection<TblMatlGrpDef> TblMatlGrpDef { get; set; }

      
    }
}
