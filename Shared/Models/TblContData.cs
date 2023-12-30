using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblContData
    {
        public TblContData()
        {
            TblContDataAttribData = new HashSet<TblContDataAttribData>();
        }

        public int ContTranUid { get; set; }
        public int? AuditScenarioUid { get; set; }
        public int MatlGrpDefUid { get; set; }
        public string AuditNum { get; set; } = null!;
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }
        public string TranType { get; set; } = null!;
        public int AuditTypeUid { get; set; }
        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual TblAuditScenario? AuditScenarioU { get; set; }
        public virtual TblAuditType AuditTypeU { get; set; } = null!;
        public virtual TblMatlGrpDef MatlGrpDefU { get; set; } = null!;
        public virtual ICollection<TblContDataAttribData> TblContDataAttribData { get; set; }
    }
}
