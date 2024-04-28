using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы ошибок
    /// </summary>
    [Index("guid", Name = "UQ__errorgroup__32C22C7C", IsUnique = true)]
    [Index("parentid", Name = "idx_errorgroup_parentid")]
    public partial class errorgroup
    {
        public errorgroup()
        {
            error = new HashSet<error>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iderrorgroup { get; set; }
        /// <summary>
        /// Ссылка на родителя
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("iderrorgroupNavigation")]
        public virtual ICollection<error> error { get; set; }
    }
}
