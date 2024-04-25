using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_optimdoc
    {
        public int idoptimdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idpeople { get; set; }
        public int? idorder { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? idstoredoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idoptimdocgroup { get; set; }
        public int? iddocstate { get; set; }
        public int? posgroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? manufactdoc_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedoc_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
    }
}
