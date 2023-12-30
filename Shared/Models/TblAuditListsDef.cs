using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditListsDef
    {
        public int AuditListsUid { get; set; }
        public string Name { get; set; } = null!;
        public string GroupName { get; set; } = null!;
        public bool Deleted { get; set; }
    }
}
