using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы типов проёмов
    /// </summary>
    [Index("parentid", Name = "idx_embrasuretypegroup_parentid")]
    public partial class embrasuretypegroup
    {
        public embrasuretypegroup()
        {
            embrasuretype = new HashSet<embrasuretype>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idembrasuretypegroup { get; set; }
        /// <summary>
        /// Ссылка на родительскую группу
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Активность группы
        /// </summary>
        [Required]
        public bool? isactive { get; set; }
        /// <summary>
        /// Признак удалённости
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idembrasuretypegroupNavigation")]
        public virtual ICollection<embrasuretype> embrasuretype { get; set; }
    }
}
