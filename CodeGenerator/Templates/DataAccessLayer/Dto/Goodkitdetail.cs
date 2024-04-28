using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodkitdetail__69534757", IsUnique = true)]
    [Index("idgood", Name = "idx_goodkitdetail_idgood")]
    [Index("idgoodkit", Name = "idx_goodkitdetail_idgoodkit")]
    [Index("width", Name = "idx_goodkitdetail_width")]
    public partial class goodkitdetail
    {
        [Key]
        public int idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public int? idgood { get; set; }
        public short? isconst { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public bool? ismain { get; set; }
        /// <summary>
        /// Цвет 1
        /// </summary>
        public int? idcolor1 { get; set; }
        /// <summary>
        /// Цвет 2
        /// </summary>
        public int? idcolor2 { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodkitdetail")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodkit")]
        [InverseProperty("goodkitdetail")]
        public virtual goodkit? idgoodkitNavigation { get; set; }
    }
}
