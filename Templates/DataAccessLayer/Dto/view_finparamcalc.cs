using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_finparamcalc
    {
        public int idfinparamcalc { get; set; }
        public int? idfinparam { get; set; }
        public int? idmodel { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public byte[]? smcrypt { get; set; }
        public byte[]? smbasecrypt { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        public int? idorderitem { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? finparam_name { get; set; }
        [Column(TypeName = "text")]
        public string? finparam_comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? finparam_paramgroup { get; set; }
        public int? finparam_numpos { get; set; }
        public short? finparam_activeparam { get; set; }
        public int? typ { get; set; }
        public int? orderitem_numpos { get; set; }
    }
}
