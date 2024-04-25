using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы должностей
    /// </summary>
    [Index("parentid", Name = "idx_peoplepostgroup_parentid")]
    public partial class peoplepostgroup
    {
        public peoplepostgroup()
        {
            peoplepost = new HashSet<peoplepost>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idpeoplepostgroup { get; set; }
        /// <summary>
        /// Ссылка на верхний уровень
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// Наименование группы
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
        public bool? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idpeoplepostgroupNavigation")]
        public virtual ICollection<peoplepost> peoplepost { get; set; }
    }
}
