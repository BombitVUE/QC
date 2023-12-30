using System;
using System.Collections.Generic;

namespace DDC_QC.Shared.Models
{
    public partial class TblContDataAttribData
    {
        public int ContDataAttribDataUid { get; set; }
        public int ContDataAttribDefUid { get; set; }
        public int ContTranUid { get; set; }
        public string Value { get; set; } = null!;
        public bool Deleted { get; set; }
        public DateTime? RevNo { get; set; }

        public virtual TblContDataAttribDef ContDataAttribDefU { get; set; } = null!;
        public virtual TblContData ContTranU { get; set; } = null!;
    }
}
