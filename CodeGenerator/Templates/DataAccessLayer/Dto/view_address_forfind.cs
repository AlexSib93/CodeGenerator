using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_address_forfind
    {
        public long? idaddress { get; set; }
        public int? idaddregion { get; set; }
        public int? idaddarea { get; set; }
        public int? idaddcity { get; set; }
        public int? idaddcityregion { get; set; }
        public int? idaddstreet { get; set; }
        public int? idaddbuild { get; set; }
        public int? build { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? build_str { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? building { get; set; }
        public int? doorway { get; set; }
        public int? apartment { get; set; }
        public int? floor { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? speakerphone { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addinfo { get; set; }
        public int? freightlift { get; set; }
        public int? passengerlift { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? build_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? street_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? cityregion_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? city_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? city_shortname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? area_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? region_name { get; set; }
        public int? postindex { get; set; }
    }
}
