using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_signgroup_from_grants
    {
        public int? idsigngroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }
        public int? idpeoplegroup { get; set; }
        public int? iddocoper { get; set; }
    }
}
