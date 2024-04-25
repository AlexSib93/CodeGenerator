using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник типов проёмов
    /// </summary>
    [Index("idembrasuretypegroup", Name = "idx_embrasuretype_idembrasuretypegroup")]
    public partial class embrasuretype
    {
        public embrasuretype()
        {
            sizedocconstrtype = new HashSet<sizedocconstrtype>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idembrasuretype { get; set; }
        /// <summary>
        /// Наименование типа проёма
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Ссылка на группу
        /// </summary>
        public int? idembrasuretypegroup { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Сокращённое наименование
        /// </summary>
        [StringLength(50)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idembrasuretypegroup")]
        [InverseProperty("embrasuretype")]
        public virtual embrasuretypegroup? idembrasuretypegroupNavigation { get; set; }
        [InverseProperty("idembrasuretypeNavigation")]
        public virtual ICollection<sizedocconstrtype> sizedocconstrtype { get; set; }
    }
}
