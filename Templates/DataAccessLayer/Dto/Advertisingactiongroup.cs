using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы рекламных акций
    /// </summary>
    [Index("parentid", Name = "idx_advertisingactiongroup_parentid")]
    public partial class advertisingactiongroup
    {
        public advertisingactiongroup()
        {
            advertisingaction = new HashSet<advertisingaction>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idadvertisingactiongroup { get; set; }
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

        [InverseProperty("idadvertisingactiongroupNavigation")]
        public virtual ICollection<advertisingaction> advertisingaction { get; set; }
    }
}
