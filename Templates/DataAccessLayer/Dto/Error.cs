using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник ошибок расчётов
    /// </summary>
    [Index("guid", Name = "UQ__error__3C4B96B6", IsUnique = true)]
    [Index("iderrorgroup", Name = "idx_error_iderrorgroup")]
    [Index("iderrortype", Name = "idx_error_iderrortype")]
    public partial class error
    {
        public error()
        {
            calcerror = new HashSet<calcerror>();
            insertiondetail = new HashSet<insertiondetail>();
            insertionparam = new HashSet<insertionparam>();
            ordererror = new HashSet<ordererror>();
            shtapikgroupdetail = new HashSet<shtapikgroupdetail>();
            variantdetail = new HashSet<variantdetail>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int iderror { get; set; }
        /// <summary>
        /// Ссылка на группу
        /// </summary>
        public int? iderrorgroup { get; set; }
        /// <summary>
        /// Ссылка на тип
        /// </summary>
        public int? iderrortype { get; set; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? code { get; set; }
        /// <summary>
        /// Наименование ошибки
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        /// <summary>
        /// Сообщение 1 об ошибке
        /// </summary>
        [Unicode(false)]
        public string? message1 { get; set; }
        /// <summary>
        /// Сообщение 2 об ошибке
        /// </summary>
        [Unicode(false)]
        public string? message2 { get; set; }
        /// <summary>
        /// Сообщение 3 об ошибке
        /// </summary>
        [Unicode(false)]
        public string? message3 { get; set; }
        /// <summary>
        /// Иллюстрация
        /// </summary>
        public byte[]? picture { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        [Unicode(false)]
        public string? comment { get; set; }
        /// <summary>
        /// Дата и время удаления
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Глобальный идентификатор для репликации
        /// </summary>
        public Guid guid { get; set; }
        /// <summary>
        /// Тип отображения. 0-не отображать,1-message1,2-message2,3-message3
        /// </summary>
        public int? showtype { get; set; }
        /// <summary>
        /// Сохранять в заказе
        /// </summary>
        public bool? issave { get; set; }

        [ForeignKey("iderrorgroup")]
        [InverseProperty("error")]
        public virtual errorgroup? iderrorgroupNavigation { get; set; }
        [ForeignKey("iderrortype")]
        [InverseProperty("error")]
        public virtual errortype? iderrortypeNavigation { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<calcerror> calcerror { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<insertiondetail> insertiondetail { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<ordererror> ordererror { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<shtapikgroupdetail> shtapikgroupdetail { get; set; }
        [InverseProperty("iderrorNavigation")]
        public virtual ICollection<variantdetail> variantdetail { get; set; }
    }
}
