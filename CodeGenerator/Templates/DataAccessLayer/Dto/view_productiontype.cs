using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontype
    {
        public int idproductiontype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontypegroup { get; set; }
        public byte[]? picture { get; set; }
        public Guid guid { get; set; }
        public int? idproductiontypegroup { get; set; }
        public int? idconstructiontype { get; set; }
        public int? typ { get; set; }
        public string? typ_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? constructiontype_name { get; set; }
        public bool isactive { get; set; }
        public int? idmeasure { get; set; }
        public int? measure_typ { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        public int? idpower { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? power_name { get; set; }
        public int? idcolorgroupcustom { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroupcustom_name { get; set; }
        public bool? onlytemplate { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name_strkey { get; set; }
    }
}
