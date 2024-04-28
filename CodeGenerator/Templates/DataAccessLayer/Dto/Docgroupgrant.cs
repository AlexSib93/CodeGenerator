using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица прав на группы документов
    /// </summary>
    [Index("iddocappearance", Name = "idx_docgroupgrant_iddocappearance")]
    public partial class docgroupgrant
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddocgroupgrant { get; set; }
        /// <summary>
        /// Вид документа
        /// </summary>
        public int iddocappearance { get; set; }
        public int iddocgroup { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Группа пользователей
        /// </summary>
        public int? idpeoplegroup { get; set; }
        /// <summary>
        /// Разрешить доступ
        /// </summary>
        public bool allow { get; set; }
        /// <summary>
        /// Запретить доступ
        /// </summary>
        public bool dany { get; set; }

        [ForeignKey("iddocappearance")]
        [InverseProperty("docgroupgrant")]
        public virtual docappearance iddocappearanceNavigation { get; set; } = null!;
    }
}
