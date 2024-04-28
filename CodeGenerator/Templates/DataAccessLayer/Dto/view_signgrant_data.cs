using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_signgrant_data
    {
        [StringLength(36)]
        [Unicode(false)]
        public string? key { get; set; }
        [StringLength(36)]
        [Unicode(false)]
        public string? parentkey { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        public int? idpeoplegroup { get; set; }
        public int? idsigngrant { get; set; }
        public bool? isadd { get; set; }
        public bool? iseditstr { get; set; }
        public bool? iseditint { get; set; }
        public bool? iseditcomment { get; set; }
        public bool? isremove { get; set; }
        public bool? isedit { get; set; }
        public int? iddocoper { get; set; }
        public int image { get; set; }
    }
}
