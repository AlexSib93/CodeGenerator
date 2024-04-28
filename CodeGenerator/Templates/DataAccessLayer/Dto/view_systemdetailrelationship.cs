using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_systemdetailrelationship
    {
        public int idsystemdetailrelationship { get; set; }
        public int idsystemdetail1 { get; set; }
        public int idsystemdetail2 { get; set; }
        public int? indent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int idsystem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? systemdetail_name1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? systemdetail_name2 { get; set; }
    }
}
