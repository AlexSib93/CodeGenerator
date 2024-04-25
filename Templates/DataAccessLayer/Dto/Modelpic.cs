using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodel", Name = "idx_modelpic_idmodel")]
    [Index("idorderitem", Name = "idx_modelpic_idorderitem")]
    [Index("idorder", Name = "ind_modelpic_idorder")]
    public partial class modelpic
    {
        [Key]
        public int idmodelpic { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Тип записи. 0-Картинки для списка конструкций в заказе, 1-Картинки для списка заказов, 2-Картинки непрямоугольных заполнений, 3-Картинки декоративных раскладок
        /// </summary>
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? Marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? markingshpross { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }

        [ForeignKey("idmodel")]
        [InverseProperty("modelpic")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("modelpic")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("modelpic")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
