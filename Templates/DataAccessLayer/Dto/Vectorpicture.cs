using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class vectorpicture
    {
        public vectorpicture()
        {
            modelparamvalue = new HashSet<modelparamvalue>();
            vectorpicturedetail = new HashSet<vectorpicturedetail>();
        }

        [Key]
        public int idvectorpicture { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column("vectorpicture")]
        public byte[]? vectorpicture1 { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? x_pos { get; set; }
        public int? y_pos { get; set; }
        [Column("using")]
        public int? _using { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? model { get; set; }

        [InverseProperty("idvectorpictureNavigation")]
        public virtual ICollection<modelparamvalue> modelparamvalue { get; set; }
        [InverseProperty("idvectorpictureNavigation")]
        public virtual ICollection<vectorpicturedetail> vectorpicturedetail { get; set; }
    }
}
