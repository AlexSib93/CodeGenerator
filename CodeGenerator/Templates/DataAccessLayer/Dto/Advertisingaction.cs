using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник рекламных акций
    /// </summary>
    [Index("idadvertisingactiongroup", Name = "idx_advertisingaction_idadvertisingactiongroup")]
    [Index("idvalut", Name = "idx_advertisingaction_idvalut")]
    public partial class advertisingaction
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idadvertisingaction { get; set; }
        /// <summary>
        /// Ссылка на группу
        /// </summary>
        public int? idadvertisingactiongroup { get; set; }
        public int? idvalut { get; set; }
        /// <summary>
        /// Наименование акции
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtstart { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtfinish { get; set; }
        /// <summary>
        /// Процент
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public bool isactive { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Удалена
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idadvertisingactiongroup")]
        [InverseProperty("advertisingaction")]
        public virtual advertisingactiongroup? idadvertisingactiongroupNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("advertisingaction")]
        public virtual valut? idvalutNavigation { get; set; }
    }
}
