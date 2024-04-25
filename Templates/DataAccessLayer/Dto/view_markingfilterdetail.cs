using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_markingfilterdetail
    {
        public int idmarkingfilterdetail { get; set; }
        public int idmarkingfilter { get; set; }
        public int idgood { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
    }
}
