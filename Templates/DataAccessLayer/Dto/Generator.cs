using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class generator
    {
        [Key]
        public int idgen { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? num { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? updatelevel { get; set; }
        public short? replicatetype { get; set; }
        public short? isdiler { get; set; }
        public short? isremoteoffice { get; set; }
        public int? shift { get; set; }
    }
}
