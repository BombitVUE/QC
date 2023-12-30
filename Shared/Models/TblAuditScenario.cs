using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditScenario
    {
        public TblAuditScenario()
        {
            TblAuditData = new HashSet<TblAuditData>();
            TblAuditScenarioConnection = new HashSet<TblAuditScenarioConnection>();
            TblContData = new HashSet<TblContData>();
        }

        public int AuditScenarioUid { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The Name min length 5")]
        public string? Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The Description min length 5")]
        public string? Description { get; set; }
        public int? AuditTypeUid { get; set; }
        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual TblAuditType? AuditTypeU { get; set; }
        public virtual ICollection<TblAuditData> TblAuditData { get; set; }
        public virtual ICollection<TblAuditScenarioConnection> TblAuditScenarioConnection { get; set; }
        public virtual ICollection<TblContData> TblContData { get; set; }
    }
    
}
