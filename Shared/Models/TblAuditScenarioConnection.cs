using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditScenarioConnection
    {
        public int AuditScenarioConnectionUid { get; set; }
        public int MatlGrpDefUid { get; set; }
        public int AuditScenarioUid { get; set; }
        public bool? Deleted { get; set; }
        public int AuditTypeUid { get; set; }

        public virtual TblAuditScenario AuditScenarioU { get; set; } = null!;
        public virtual TblAuditType AuditTypeU { get; set; } = null!;
        public virtual TblMatlGrpDef MatlGrpDefU { get; set; } = null!;
    }
}
