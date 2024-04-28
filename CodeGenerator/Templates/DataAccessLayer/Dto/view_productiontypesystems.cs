using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontypesystems
    {
        public int? idproductiontypesystems { get; set; }
        public int? idproductiontype { get; set; }
        public int? idsystem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public int? idpricechange { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        public int productiontype_idproductiontype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        public int system_idsystem { get; set; }
        public int? system_type { get; set; }
        public int? system_numpos { get; set; }
        public int _active { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroupcustom_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_name { get; set; }
    }
}
