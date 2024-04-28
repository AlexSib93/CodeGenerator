using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_systemdetailrel
    {
        public int idsystemdetailrel { get; set; }
        public int? idsystemdetail { get; set; }
        public int? idsystemdetail2 { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(257)]
        [Unicode(false)]
        public string? systemdetail_name1 { get; set; }
        [StringLength(257)]
        [Unicode(false)]
        public string? systemdetail_name2 { get; set; }
        public int? sd_modelpart { get; set; }
    }
}
