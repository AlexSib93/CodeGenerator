using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Группы типов продукции
    /// </summary>
    [Index("guid", Name = "UQ__productiontypegr__5BF94C39", IsUnique = true)]
    [Index("parentid", Name = "idx_productiontypegroup_parentid")]
    public partial class productiontypegroup
    {
        public productiontypegroup()
        {
            productiontype = new HashSet<productiontype>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idproductiontypegroup { get; set; }
        /// <summary>
        /// Ссылка на родителя
        /// </summary>
        public int? parentid { get; set; }
        /// <summary>
        /// Номер по порядку
        /// </summary>
        public int? numpos { get; set; }
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
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? isactive { get; set; }

        [InverseProperty("idproductiontypegroupNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
    }
}
