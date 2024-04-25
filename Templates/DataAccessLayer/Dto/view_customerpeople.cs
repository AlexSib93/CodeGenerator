using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerpeople
    {
        public int idcustomerpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtreg { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public int? numpos { get; set; }
        public bool? ismain { get; set; }
        public int? idpeoplepost { get; set; }
        public Guid guid { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? people_postname { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
    }
}
