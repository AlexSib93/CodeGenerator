using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_docopergrant
    {
        public int iddocoper { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? prefix { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? suffix { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docgroup { get; set; }
        public int? iddocappearance { get; set; }
        public int? agreenumpos { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? agreeprefix { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? agreesuffix { get; set; }
        public short? storetyp { get; set; }
        public Guid guid { get; set; }
        public int? addint { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        public bool? indealerbase { get; set; }
        public int? idproductionsite { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? doctype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? storetyp_name { get; set; }
        public int idpeoplegroup { get; set; }
        public int _grant { get; set; }
    }
}
