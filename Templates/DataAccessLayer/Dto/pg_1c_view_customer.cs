using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_customer
    {
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string type_customer { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? inn { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? bank { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rs { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? cs { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? okato { get; set; }
        public int? kpp { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? ogrn { get; set; }
    }
}
