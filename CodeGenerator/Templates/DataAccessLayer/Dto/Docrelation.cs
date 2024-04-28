using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица связей между документами
    /// </summary>
    [Index("iddocappearancechild", "idchilddoc", Name = "IX_docrelation_Child")]
    [Index("iddocappearanceparent", "idparentdoc", Name = "IX_docrelation_Parent")]
    [Index("iddocappearanceparent", "iddocappearancechild", Name = "docrelation2")]
    public partial class docrelation
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iddocrelation { get; set; }
        /// <summary>
        /// Ссылка на документ родитель
        /// </summary>
        public int? idparentdoc { get; set; }
        /// <summary>
        /// Вид документа родителя
        /// </summary>
        public int? iddocappearanceparent { get; set; }
        /// <summary>
        /// Ссылка на документ потомок
        /// </summary>
        public int? idchilddoc { get; set; }
        /// <summary>
        /// Вид документа потомка
        /// </summary>
        public int? iddocappearancechild { get; set; }
        /// <summary>
        /// Дата удаления связи
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
    }
}
