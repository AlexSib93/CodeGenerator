using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник типов ошибок расчётов
    /// </summary>
    [Index("guid", Name = "UQ__errortype__3786E199", IsUnique = true)]
    public partial class errortype
    {
        public errortype()
        {
            error = new HashSet<error>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iderrortype { get; set; }
        /// <summary>
        /// Наименование типа ошибки
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
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }

        [InverseProperty("iderrortypeNavigation")]
        public virtual ICollection<error> error { get; set; }
    }
}
