using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_destanationcustomer
    {
        public int iddestanationcustomer { get; set; }
        public int? iddestanation { get; set; }
        public int? idcustomer { get; set; }
        public short? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
    }
}
