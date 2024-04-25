using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Склад готовой продукции
    /// </summary>
    [Index("idmanufactdocpos", Name = "idx_rotoxhouse_idmanufactdocpos")]
    [Index("idmanufactdocpyramid", Name = "idx_rotoxhouse_idmanufactdocpyramid")]
    [Index("idorderitem", Name = "idx_rotoxhouse_idorderitem")]
    [Index("idstoragespace", Name = "idx_rotoxhouse_idstoragespace")]
    [Index("idstoragespace2", Name = "idx_rotoxhouse_idstoragespace2")]
    [Index("idstoredepart", Name = "idx_rotoxhouse_idstoredepart")]
    [Index("idstoredoc", Name = "idx_rotoxhouse_idstoredoc")]
    public partial class rotoxhouse : IRemovable
    {
        public rotoxhouse()
        {
            revisiongpitem = new HashSet<revisiongpitem>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idrotoxhouse { get; set; }
        /// <summary>
        /// Позиция заказа
        /// </summary>
        public int? idorderitem { get; set; }
        /// <summary>
        /// Мастер производство
        /// </summary>
        public int? idpeople1 { get; set; }
        /// <summary>
        /// Мастер ОТК
        /// </summary>
        public int? idpeople2 { get; set; }
        /// <summary>
        /// Принял на склад
        /// </summary>
        public int? idpeople3 { get; set; }
        /// <summary>
        /// Отгрузил со склада
        /// </summary>
        public int? idpeople4 { get; set; }
        /// <summary>
        /// Прочее (на усмотрение компаний)
        /// </summary>
        public int? idpeople5 { get; set; }
        /// <summary>
        /// Дата прихода
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtin { get; set; }
        /// <summary>
        /// Дата расхода
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtout { get; set; }
        /// <summary>
        /// Ячейка склада
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? cell { get; set; }
        /// <summary>
        /// Строка склада
        /// </summary>
        [StringLength(128)]
        [Unicode(false)]
        public string? row { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Состояние ячейки
        /// </summary>
        public int? state { get; set; }
        public int? idmodel { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        public int? idorder { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? barnumpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public int? idmanufactdocpyramid { get; set; }
        public int? idstoredoc { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idstoragespace { get; set; }
        public int? idstoragespace2 { get; set; }
        public int? idstoredepart { get; set; }

        [ForeignKey("idmanufactdocpos")]
        [InverseProperty("rotoxhouse")]
        public virtual manufactdocpos? idmanufactdocposNavigation { get; set; }
        [ForeignKey("idmanufactdocpyramid")]
        [InverseProperty("rotoxhouse")]
        public virtual manufactdocpyramid? idmanufactdocpyram { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("rotoxhouse")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [ForeignKey("idstoragespace2")]
        [InverseProperty("rotoxhouseidstoragespace2Navigation")]
        public virtual storagespace? idstoragespace2Navigation { get; set; }
        [ForeignKey("idstoragespace")]
        [InverseProperty("rotoxhouseidstoragespaceNavigation")]
        public virtual storagespace? idstoragespaceNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("rotoxhouse")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
        [ForeignKey("idstoredoc")]
        [InverseProperty("rotoxhouse")]
        public virtual storedoc? idstoredocNavigation { get; set; }
        [InverseProperty("idrotoxhouseNavigation")]
        public virtual ICollection<revisiongpitem> revisiongpitem { get; set; }
    }
}
