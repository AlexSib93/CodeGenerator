using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Этапы документа &quot;Сервис и гарантия&quot;
    /// </summary>
    [Index("iddiraction", Name = "idx_servicedocdiraction_iddiraction")]
    [Index("idpeopleexec", Name = "idx_servicedocdiraction_idpeopleexec")]
    [Index("idservicedoc", Name = "idx_servicedocdiraction_idservicedoc")]
    public partial class servicedocdiraction
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idservicedocdiraction { get; set; }
        /// <summary>
        /// Ссылка на документ сервиса
        /// </summary>
        public int? idservicedoc { get; set; }
        /// <summary>
        /// Ссылка на этап
        /// </summary>
        public int? iddiraction { get; set; }
        /// <summary>
        /// Дата удаления этапа
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Комментарий к этапу
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Плановая дата выполнения этапа
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        /// <summary>
        /// Фактическая дата выполнения этапа
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        /// <summary>
        /// Сотрудник создавший этап
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Дата создания этапа
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        /// <summary>
        /// Дата редактирования этапа
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        /// <summary>
        /// Сотрудник редактировавший этап
        /// </summary>
        public int? idpeopleedit { get; set; }
        /// <summary>
        /// Исполнитель этапа
        /// </summary>
        public int? idpeopleexec { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("servicedocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idpeopleexec")]
        [InverseProperty("servicedocdiraction")]
        public virtual people? idpeopleexecNavigation { get; set; }
        [ForeignKey("idservicedoc")]
        [InverseProperty("servicedocdiraction")]
        public virtual servicedoc? idservicedocNavigation { get; set; }
    }
}
