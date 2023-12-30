using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblContDataAttribDef
    {
        public TblContDataAttribDef()
        {
            TblContDataAttribData = new HashSet<TblContDataAttribData>();
        }

        public int ContDataAttribDefUid { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? GroupName { get; set; }
        public int ObjRef { get; set; }
        public DateTime? RevDate { get; set; }

        public virtual ICollection<TblContDataAttribData> TblContDataAttribData { get; set; }
    }
}
