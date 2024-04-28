using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица исполнителей работ по документу
    /// </summary>
    [Index("iddocwork", Name = "idx_docworkpeople_iddocwork")]
    [Index("idpeople", Name = "idx_docworkpeople_idpeople")]
    public partial class docworkpeople
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddocworkpeople { get; set; }
        /// <summary>
        /// Ссылка на работу документа
        /// </summary>
        public int? iddocwork { get; set; }
        /// <summary>
        /// Ссылка на исполнителя(справочник сотрудников)
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddocwork")]
        [InverseProperty("docworkpeople")]
        public virtual docwork? iddocworkNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("docworkpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
