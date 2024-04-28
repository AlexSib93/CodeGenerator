using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocappearance", "iddoc", Name = "IX_docwork_compare")]
    [Index("iddocappearance", "iddocitem", Name = "IX_docwork_item_compare")]
    [Index("idpeople", Name = "idx_docwork_idpeople")]
    [Index("idwork", Name = "idx_docwork_idwork")]
    [Index("idworkoper", Name = "idx_docwork_idworkoper")]
    public partial class docwork
    {
        public docwork()
        {
            docworkpeople = new HashSet<docworkpeople>();
        }

        [Key]
        public int iddocwork { get; set; }
        public int iddoc { get; set; }
        public int iddocappearance { get; set; }
        public int? idwork { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? worktime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Ссылка на сотрудника создавшего работу
        /// </summary>
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtwork { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? idworkoper { get; set; }
        /// <summary>
        /// Ссылка на позицию документа
        /// </summary>
        public int? iddocitem { get; set; }
        /// <summary>
        /// Дата и время создания
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        /// <summary>
        /// Дата и время изменения
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        /// <summary>
        /// Ссылка на сотрудника изменившего работу
        /// </summary>
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("docwork")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idwork")]
        [InverseProperty("docwork")]
        public virtual work? idworkNavigation { get; set; }
        [ForeignKey("idworkoper")]
        [InverseProperty("docwork")]
        public virtual workoper? idworkoperNavigation { get; set; }
        [InverseProperty("iddocworkNavigation")]
        public virtual ICollection<docworkpeople> docworkpeople { get; set; }
    }
}
