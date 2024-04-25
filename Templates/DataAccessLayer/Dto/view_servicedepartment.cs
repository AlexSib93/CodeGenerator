using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_servicedepartment
    {
        public int idservicedepartment { get; set; }
        public int idservicedoc { get; set; }
        public int? iddepartment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 3)")]
        public decimal? perc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 3)")]
        public decimal? smbase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? servicedoc_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? department_name { get; set; }
    }
}
