using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_diractiongrant_data
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
        public int? iddiraction { get; set; }
        public int? idpeoplegroup { get; set; }
        public int? iddiractiongrant { get; set; }
        public short? isadd { get; set; }
        public short? iseditplan { get; set; }
        public short? iseditfact { get; set; }
        public short? iseditcomment { get; set; }
        public short? iseditexecutor { get; set; }
        public short? isremove { get; set; }
        public int? iddocoper { get; set; }
        public int image { get; set; }
    }
}
