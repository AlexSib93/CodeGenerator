using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы характеристик
    /// </summary>
    [Index("parentid", Name = "idx_modelparamgroup_parentid")]
    public partial class modelparamgroup
    {
        public modelparamgroup()
        {
            modelparam = new HashSet<modelparam>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idmodelparamgroup { get; set; }
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
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Дата удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }

        [InverseProperty("idmodelparamgroupNavigation")]
        public virtual ICollection<modelparam> modelparam { get; set; }
    }
}
