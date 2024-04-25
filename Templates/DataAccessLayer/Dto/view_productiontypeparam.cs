using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontypeparam
    {
        public int idproductiontypeparam { get; set; }
        public int? idproductiontype { get; set; }
        public int? idmodelparam { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue1 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numericvalue1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numericvalue2 { get; set; }
        public bool? isstr1 { get; set; }
        public bool? isstr2 { get; set; }
        public bool? isnumeric1 { get; set; }
        public bool? isnumeric2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idmodelparamvalue2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelparam_name { get; set; }
        public int? modelparam_numpos { get; set; }
    }
}
