using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class rotoxflugel
    {
        [Key]
        public int idrotoxflugel { get; set; }
        public int? num { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
    }
}
