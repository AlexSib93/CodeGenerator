using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы источников информации
    /// </summary>
    [Index("parentid", Name = "idx_sourceinfogroup_parentid")]
    public partial class sourceinfogroup
    {
        public sourceinfogroup()
        {
            sourceinfo = new HashSet<sourceinfo>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idsourceinfogroup { get; set; }
        /// <summary>
        /// Ссылка на родителя
        /// </summary>
        public int? parentid { get; set; }
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
        /// <summary>
        /// Активность группы
        /// </summary>
        public bool? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idsourceinfogroupNavigation")]
        public virtual ICollection<sourceinfo> sourceinfo { get; set; }
    }
}
