using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Входящие остатки производственного задания
    /// </summary>
    [Index("idmanufactdoc", Name = "idx_manufactdocgoodin_idmanufactdoc")]
    public partial class manufactdocgoodin
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idmanufactdocgoodin { get; set; }
        /// <summary>
        /// Ссылка на производственное задание
        /// </summary>
        public int? idmanufactdoc { get; set; }
        /// <summary>
        /// Артикул материала
        /// </summary>
        [Unicode(false)]
        public string? marking { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int? qu { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public int? thick { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public int? height { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public int? width { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Признак удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idmanufactdoc")]
        [InverseProperty("manufactdocgoodin")]
        public virtual manufactdoc? idmanufactdocNavigation { get; set; }
    }
}
