using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditType
    {
        public TblAuditType()
        {
            TblAuditScenario = new HashSet<TblAuditScenario>();
            TblAuditScenarioConnection = new HashSet<TblAuditScenarioConnection>();
            TblContData = new HashSet<TblContData>();
        }

        public int AuditTypeUid { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TblAuditScenario> TblAuditScenario { get; set; }
        public virtual ICollection<TblAuditScenarioConnection> TblAuditScenarioConnection { get; set; }
        public virtual ICollection<TblContData> TblContData { get; set; }
    }
}
