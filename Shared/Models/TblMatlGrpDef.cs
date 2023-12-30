using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblMatlGrpDef
    {
        public TblMatlGrpDef()
        {
            TblAuditScenarioConnection = new HashSet<TblAuditScenarioConnection>();
            TblContData = new HashSet<TblContData>();
        }

        public int MatlGrpDefUid { get; set; }
        public int ProcGrpUid { get; set; }
        public string Model { get; set; } = null!;
        public string PosCode { get; set; } = null!;
        public string? Description { get; set; }
        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual TblProcGrp ProcGrpU { get; set; } = null!;
        public virtual ICollection<TblAuditScenarioConnection> TblAuditScenarioConnection { get; set; }
        public virtual ICollection<TblContData> TblContData { get; set; }
    }
}
