using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник автомобилей
    /// </summary>
    [Index("guid", Name = "UQ_car_guid", IsUnique = true)]
    [Index("idcarmarking", Name = "idx_car_idcarmarking")]
    [Index("idproductionsite", Name = "idx_car_idproductionsite")]
    [Index("idtariff", Name = "idx_car_idtariff")]
    public partial class car
    {
        public car()
        {
            cartariff = new HashSet<cartariff>();
            delivdoc = new HashSet<delivdoc>();
            manufactdoccar = new HashSet<manufactdoccar>();
            manufactdocorder = new HashSet<manufactdocorder>();
            pyramid = new HashSet<pyramid>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idcar { get; set; }
        /// <summary>
        /// Ссылка на марку автомобиля
        /// </summary>
        public int? idcarmarking { get; set; }
        /// <summary>
        /// Ссылка на пирамиду
        /// </summary>
        public int? idpyramid { get; set; }
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
        /// Гос.номер
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? statesign { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? active { get; set; }
        public int? idproductionsite { get; set; }
        public int? idtariff { get; set; }

        [ForeignKey("idcarmarking")]
        [InverseProperty("car")]
        public virtual carmarking? idcarmarkingNavigation { get; set; }
        [ForeignKey("idproductionsite")]
        [InverseProperty("car")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [ForeignKey("idtariff")]
        [InverseProperty("car")]
        public virtual tariff? idtariffNavigation { get; set; }
        [InverseProperty("idcarNavigation")]
        public virtual ICollection<cartariff> cartariff { get; set; }
        [InverseProperty("idcarNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idcarNavigation")]
        public virtual ICollection<manufactdoccar> manufactdoccar { get; set; }
        [InverseProperty("idcarNavigation")]
        public virtual ICollection<manufactdocorder> manufactdocorder { get; set; }
        [InverseProperty("idcarNavigation")]
        public virtual ICollection<pyramid> pyramid { get; set; }
    }
}
