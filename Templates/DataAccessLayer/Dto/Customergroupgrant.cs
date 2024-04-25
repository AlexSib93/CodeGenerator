using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Таблица прав на группы документов
    /// </summary>
    public partial class customergroupgrant
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idcustomergroupgrant { get; set; }
        /// <summary>
        /// Группа контрагентов
        /// </summary>
        public int idcustomergroup { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Группа пользователей
        /// </summary>
        public int? idpeoplegroup { get; set; }
        /// <summary>
        /// Разрешить доступ
        /// </summary>
        public bool allow { get; set; }
        /// <summary>
        /// Запретить доступ
        /// </summary>
        public bool dany { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
    }
}
