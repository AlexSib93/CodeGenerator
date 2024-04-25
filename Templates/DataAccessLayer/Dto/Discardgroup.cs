using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы дисконтных карт
    /// </summary>
    [Index("parentid", Name = "idx_discardgroup_parentid")]
    public partial class discardgroup
    {
        public discardgroup()
        {
            discard = new HashSet<discard>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddiscardgroup { get; set; }
        /// <summary>
        /// Ссылка на родителя
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// Наименование группы
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Процент скидки
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        /// <summary>
        /// Сумма скидки
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
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

        [InverseProperty("iddiscardgroupNavigation")]
        public virtual ICollection<discard> discard { get; set; }
    }
}
