using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_adresselement
    {
        public int? idaddregion { get; set; }
        public int? idaddarea { get; set; }
        public int? idaddcity { get; set; }
        public int? idaddcityregion { get; set; }
        public int? idaddstreet { get; set; }
        public int? idaddbuild { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? region_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? area_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? city_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? cityregion_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? street_name { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? build_name { get; set; }
        public int? postindex { get; set; }
    }
}
