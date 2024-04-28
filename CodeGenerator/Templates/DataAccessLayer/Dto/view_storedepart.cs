using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_storedepart
    {
        public int idstoredepart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? departgroup { get; set; }
        public int? idproductionsite { get; set; }
        public int? idavailabilitygroup { get; set; }
        public int? typ { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? availabilitygroup_name { get; set; }
        [StringLength(17)]
        [Unicode(false)]
        public string? typ_name { get; set; }
    }
}
