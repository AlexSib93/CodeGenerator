using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderdiraction
    {
        public int idorderdiraction { get; set; }
        public int? iddiraction { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        public int? idpeople3 { get; set; }
        public int? idorderitem { get; set; }
        public int? orderitemnum { get; set; }
        public int? workshop { get; set; }
        public int? poolnum { get; set; }
        public int? posgroup { get; set; }
        public int? poolnumcustom { get; set; }
        public int? duration { get; set; }
        public int? sortnum { get; set; }
        public int? numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? diraction_name { get; set; }
        public int? diraction_numpos { get; set; }
        public int? diraction_duration { get; set; }
        public short? diraction_autosave { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peopleedit_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio3 { get; set; }
        public Guid diraction_guid { get; set; }
    }
}
