using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_optimdocdiraction_iddiraction")]
    [Index("idoptimdoc", Name = "idx_optimdocdiraction_idoptimdoc")]
    [Index("idpeople", Name = "idx_optimdocdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_optimdocdiraction_idpeopleedit")]
    [Index("idpeopleexec", Name = "idx_optimdocdiraction_idpeopleexec")]
    public partial class optimdocdiraction
    {
        [Key]
        public int idoptimdocdiraction { get; set; }
        public int? idoptimdoc { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        /// <summary>
        /// Пользователь, создавший этап
        /// </summary>
        public int? idpeople { get; set; }
        /// <summary>
        /// Пользователь, редактировавший этап
        /// </summary>
        public int? idpeopleedit { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
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
        /// Исполнитель этапа
        /// </summary>
        public int? idpeopleexec { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("optimdocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idoptimdoc")]
        [InverseProperty("optimdocdiraction")]
        public virtual optimdoc? idoptimdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("optimdocdiractionidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleedit")]
        [InverseProperty("optimdocdiractionidpeopleeditNavigation")]
        public virtual people? idpeopleeditNavigation { get; set; }
        [ForeignKey("idpeopleexec")]
        [InverseProperty("optimdocdiractionidpeopleexecNavigation")]
        public virtual people? idpeopleexecNavigation { get; set; }
    }
}
