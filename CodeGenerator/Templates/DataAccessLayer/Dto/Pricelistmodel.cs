using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class pricelistmodel
    {
        [Key]
        public int idpricelistmodel { get; set; }
        public int? idpricelist { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? classnative { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public short? typ { get; set; }
        public int? idconstruction { get; set; }
    }
}
