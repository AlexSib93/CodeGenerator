using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Скидки\наценки контрагентов
    /// </summary>
    [Index("guid", Name = "UQ__customerpricecha__19025A79", IsUnique = true)]
    [Index("idcustomer", Name = "idx_customerpricechange_idcustomer")]
    [Index("idpricechange", Name = "idx_customerpricechange_idpricechange")]
    [Index("idseller", Name = "idx_customerpricechange_idseller")]
    public partial class customerpricechange
    {
        public customerpricechange()
        {
            customerpricechangehistory = new HashSet<customerpricechangehistory>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idcustomerpricechange { get; set; }
        /// <summary>
        /// Ссылка на контрагента
        /// </summary>
        public int? idcustomer { get; set; }
        /// <summary>
        /// Ссылка на скидку\наценку
        /// </summary>
        public int? idpricechange { get; set; }
        /// <summary>
        /// Значение скидки\наценки
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        /// <summary>
        /// Ссылка на продавца
        /// </summary>
        public int? idseller { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Глобальный идентификатор
        /// </summary>
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? startdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? enddate { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerpricechange")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("customerpricechange")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("customerpricechange")]
        public virtual seller? idsellerNavigation { get; set; }
        [InverseProperty("idcustomerpricechangeNavigation")]
        public virtual ICollection<customerpricechangehistory> customerpricechangehistory { get; set; }
    }
}
