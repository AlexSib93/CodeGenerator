using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Права на этапы
    /// </summary>
    [Index("iddiraction", Name = "idx_diractiongrant_iddiraction")]
    [Index("iddocoper", Name = "idx_diractiongrant_iddocoper")]
    [Index("idpeoplegroup", Name = "idx_diractiongrant_idpeoplegroup")]
    public partial class diractiongrant
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddiractiongrant { get; set; }
        /// <summary>
        /// Ссылка на этап
        /// </summary>
        public int? iddiraction { get; set; }
        /// <summary>
        /// Ссылка на группу пользователей
        /// </summary>
        public int? idpeoplegroup { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Ссылка на тип документа
        /// </summary>
        public int? iddocoper { get; set; }
        /// <summary>
        /// Права на редактирование плановой даты
        /// </summary>
        public short? iseditplan { get; set; }
        /// <summary>
        /// Права на редактирование фактической даты
        /// </summary>
        public short? iseditfact { get; set; }
        /// <summary>
        /// Права на редактирование комментария
        /// </summary>
        public short? iseditcomment { get; set; }
        /// <summary>
        /// Права на редактирование исполнителей
        /// </summary>
        public short? iseditexecutor { get; set; }
        /// <summary>
        /// Права на добавление
        /// </summary>
        public short? isadd { get; set; }
        /// <summary>
        /// Права на удаление
        /// </summary>
        public short? isremove { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("diractiongrant")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("diractiongrant")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("diractiongrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
    }
}
