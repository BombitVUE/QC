using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDC_QC.Shared.Models
{
    public partial class TblAuditArticleDef
    {
        public TblAuditArticleDef()
        {
            TblAuditData = new HashSet<TblAuditData>();
        }

        public int AuditArticleDefUid { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "The Name min length 4")]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(5, ErrorMessage = "The Tittle min length 4")]
        public string Tittle { get; set; } = null!;
        [Required]
        [MinLength(5, ErrorMessage = "The Content min length 4")]
        public string Content { get; set; } = null!;
        public int ContDataAttribDefUid { get; set; }
        public bool Deleted { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual ICollection<TblAuditData> TblAuditData { get; set; }
    }
}
