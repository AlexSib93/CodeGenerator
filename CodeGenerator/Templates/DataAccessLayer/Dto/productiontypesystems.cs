using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица связей продукции с системами профиля, фурнитуры, типами конструкций etc.
    /// </summary>
    [Index("idcolorgroupcustom", Name = "idx_productiontypesystems_idcolorgroupcustom")]
    [Index("idpricechange", Name = "idx_productiontypesystems_idpricechange")]
    [Index("idproductiontype", Name = "idx_productiontypesystems_idproductiontype")]
    [Index("idsystem", Name = "idx_productiontypesystems_idsystem")]
    public partial class productiontypesystems
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idproductiontypesystems { get; set; }
        /// <summary>
        /// Ссылка на тип продукции
        /// </summary>
        public int? idproductiontype { get; set; }
        /// <summary>
        /// Ссылка на связанное значение в системах
        /// </summary>
        public int? idsystem { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public int? idpricechange { get; set; }

        [ForeignKey("idcolorgroupcustom")]
        [InverseProperty("productiontypesystems")]
        public virtual colorgroupcustom? idcolorgroupcustomNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("productiontypesystems")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypesystems")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idsystem")]
        [InverseProperty("productiontypesystems")]
        public virtual system? idsystemNavigation { get; set; }
    }
}
