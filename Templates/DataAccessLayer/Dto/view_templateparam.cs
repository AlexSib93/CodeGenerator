using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_templateparam
    {
        public int idtemplateparam { get; set; }
        public int? idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
        public int? idtemplate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelparam_name { get; set; }
        public int? template_idproductiontype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart_name { get; set; }
    }
}
