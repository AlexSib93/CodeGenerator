using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица зданий
    /// </summary>
    [Index("idaddcityregion", Name = "idx_addbuild_idaddcityregion")]
    [Index("idaddstreet", Name = "idx_addbuild_idaddstreet")]
    public partial class addbuild
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idaddbuild { get; set; }
        /// <summary>
        /// Ссылка на улицу
        /// </summary>
        public int? idaddstreet { get; set; }
        /// <summary>
        /// Ссылка на район города(в некоторых городах улица может проходить через несколько районов города)
        /// </summary>
        public int? idaddcityregion { get; set; }
        /// <summary>
        /// Номер здания
        /// </summary>
        [StringLength(50)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        public int? postindex { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }

        [ForeignKey("idaddcityregion")]
        [InverseProperty("addbuild")]
        public virtual addcityregion? idaddcityregionNavigation { get; set; }
        [ForeignKey("idaddstreet")]
        [InverseProperty("addbuild")]
        public virtual addstreet? idaddstreetNavigation { get; set; }
    }
}
