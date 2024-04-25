using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiontypesetting
    {
        public int idproductiontypesetting { get; set; }
        public int idproductiontype { get; set; }
        public int idsetting { get; set; }
        [Column(TypeName = "text")]
        public string? txtvalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? setting_name { get; set; }
        public byte[]? setting_namecrypt { get; set; }
        public bool? setting_addmodel { get; set; }
        public bool? setting_addorder { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        public bool productiontype_isactive { get; set; }
    }
}
