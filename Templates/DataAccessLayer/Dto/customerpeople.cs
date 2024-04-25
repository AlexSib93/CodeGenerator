using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerpeople_idcustomer")]
    [Index("idpeople", Name = "idx_customerpeople_idpeople")]
    [Index("idpeoplepost", Name = "idx_customerpeople_idpeoplepost")]
    public partial class customerpeople
    {
        [Key]
        public int idcustomerpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtreg { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        /// <summary>
        /// Номер по порядку
        /// </summary>
        public int? numpos { get; set; }
        /// <summary>
        /// Основной сотрудник
        /// </summary>
        public bool? ismain { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public int? idpeoplepost { get; set; }
        public Guid guid { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt2 { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerpeople")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("customerpeople")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeoplepost")]
        [InverseProperty("customerpeople")]
        public virtual peoplepost? idpeoplepostNavigation { get; set; }
    }
}
