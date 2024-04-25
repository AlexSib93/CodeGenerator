using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerdiscard
    {
        public int idcustomerdiscard { get; set; }
        public int? idcustomer { get; set; }
        public int? iddiscard { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? discard_comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? discard_dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? discard_inactivedate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? discard_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discard_perc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discard_sm { get; set; }
        public int? discard_idpeople { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? discard_people_fio { get; set; }
    }
}
