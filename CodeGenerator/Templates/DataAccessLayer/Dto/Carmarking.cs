using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник марок автомобилей
    /// </summary>
    [Index("guid", Name = "UQ_carmarking_guid", IsUnique = true)]
    public partial class carmarking
    {
        public carmarking()
        {
            car = new HashSet<car>();
            carmarkingroute = new HashSet<carmarkingroute>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idcarmarking { get; set; }
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
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? tonnage { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? tonnageue { get; set; }
        public int? width { get; set; }
        public int? length { get; set; }
        public int? maxroute { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxsqr { get; set; }

        [InverseProperty("idcarmarkingNavigation")]
        public virtual ICollection<car> car { get; set; }
        [InverseProperty("idcarmarkingNavigation")]
        public virtual ICollection<carmarkingroute> carmarkingroute { get; set; }
    }
}
