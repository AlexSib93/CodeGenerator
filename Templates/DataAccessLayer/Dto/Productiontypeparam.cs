using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Параметры типов продукции
    /// </summary>
    [Index("guid", Name = "UQ__productiontypepa__3D74C519", IsUnique = true)]
    [Index("idmodelparam", Name = "idx_productiontypeparam_idmodelparam")]
    [Index("idmodelparamvalue", Name = "idx_productiontypeparam_idmodelparamvalue")]
    [Index("idmodelparamvalue2", Name = "idx_productiontypeparam_idmodelparamvalue2")]
    [Index("idproductiontype", Name = "idx_productiontypeparam_idproductiontype")]
    public partial class productiontypeparam
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idproductiontypeparam { get; set; }
        /// <summary>
        /// Ссылка на тип продукции
        /// </summary>
        public int? idproductiontype { get; set; }
        /// <summary>
        /// Ссылка на параметр
        /// </summary>
        public int? idmodelparam { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue1 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numericvalue1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numericvalue2 { get; set; }
        public bool? isstr1 { get; set; }
        public bool? isstr2 { get; set; }
        public bool? isnumeric1 { get; set; }
        public bool? isnumeric2 { get; set; }
        /// <summary>
        /// Дата удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        public int? idmodelparamvalue { get; set; }
        public int? idmodelparamvalue2 { get; set; }

        [ForeignKey("idmodelparam")]
        [InverseProperty("productiontypeparam")]
        public virtual modelparam? idmodelparamNavigation { get; set; }
        [ForeignKey("idmodelparamvalue2")]
        [InverseProperty("productiontypeparamidmodelparamvalue2Navigation")]
        public virtual modelparamvalue? idmodelparamvalue2Navigation { get; set; }
        [ForeignKey("idmodelparamvalue")]
        [InverseProperty("productiontypeparamidmodelparamvalueNavigation")]
        public virtual modelparamvalue? idmodelparamvalueNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypeparam")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
    }
}
