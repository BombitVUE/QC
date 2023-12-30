using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditData
    {
        public int AuditDataUid { get; set; }
        public int AuditScenarioUid { get; set; }
        public int AuditArticleDefUid { get; set; }
        public int Order { get; set; }

        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual TblAuditArticleDef? AuditArticleDefU { get; set; } = null;
        public virtual TblAuditScenario? AuditScenarioU { get; set; } = null;
      
    }
}
