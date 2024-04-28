using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник иточников информации
    /// </summary>
    [Index("idsourceinfogroup", Name = "idx_sourceinfo_idsourceinfogroup")]
    public partial class sourceinfo
    {
        public sourceinfo()
        {
            customer = new HashSet<customer>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idsourceinfo { get; set; }
        /// <summary>
        /// Ссылка на группу
        /// </summary>
        public int? idsourceinfogroup { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Признак удалённости
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idsourceinfogroup")]
        [InverseProperty("sourceinfo")]
        public virtual sourceinfogroup? idsourceinfogroupNavigation { get; set; }
        [InverseProperty("idsourceinfoNavigation")]
        public virtual ICollection<customer> customer { get; set; }
    }
}
