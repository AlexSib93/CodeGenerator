using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class pyramidfactpos
    {
        [Key]
        public int idpyramidfactpos { get; set; }
        public int? idpyramidfact { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idgood { get; set; }
        public int? idorder { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? barcode { get; set; }
    }
}
