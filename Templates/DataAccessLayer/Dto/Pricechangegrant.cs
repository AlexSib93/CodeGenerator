using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Права на скидки и наценки
    /// </summary>
    [Index("idpeoplegroup", Name = "idx_pricechangegrant_idpeoplegroup")]
    [Index("idpricechange", Name = "idx_pricechangegrant_idpricechange")]
    public partial class pricechangegrant
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idpricechangegrant { get; set; }
        /// <summary>
        /// Ссылка на скидку
        /// </summary>
        public int? idpricechange { get; set; }
        /// <summary>
        /// Скидка на группу пользователей
        /// </summary>
        public int? idpeoplegroup { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Required]
        public bool? isedit { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idpeoplegroup")]
        [InverseProperty("pricechangegrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("pricechangegrant")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
    }
}
