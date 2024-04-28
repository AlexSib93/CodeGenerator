using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idvectorpicture", Name = "idx_vectorpicturedetail_idvectorpicture")]
    public partial class vectorpicturedetail
    {
        [Key]
        public int idvectorpicturedetail { get; set; }
        public int? idvectorpicture { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? x1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? y1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? ang { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idvectorpicture")]
        [InverseProperty("vectorpicturedetail")]
        public virtual vectorpicture? idvectorpictureNavigation { get; set; }
    }
}
