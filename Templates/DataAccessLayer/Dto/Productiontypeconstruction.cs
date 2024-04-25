using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица связей продукции с типами конструкций
    /// </summary>
    [Index("idconstructiontype", Name = "idx_productiontypeconstruction_idconstructiontype")]
    [Index("idproductiontype", Name = "idx_productiontypeconstruction_idproductiontype")]
    public partial class productiontypeconstruction
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idproductiontypeconstruction { get; set; }
        /// <summary>
        /// Ссылка на тип продукции
        /// </summary>
        public int? idproductiontype { get; set; }
        /// <summary>
        /// Ссылка тип конструкции
        /// </summary>
        public int? idconstructiontype { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("productiontypeconstruction")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypeconstruction")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
    }
}
