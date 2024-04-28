using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_sizedocdiraction_iddiraction")]
    [Index("idpeople", Name = "idx_sizedocdiraction_idpeople")]
    [Index("idpeopleedit", Name = "idx_sizedocdiraction_idpeopleedit")]
    [Index("idpeopleexec", Name = "idx_sizedocdiraction_idpeopleexec")]
    [Index("idsizedoc", Name = "idx_sizedocdiraction_idsizedoc")]
    public partial class sizedocdiraction
    {
        public sizedocdiraction()
        {
            sizedocdiractionpeople = new HashSet<sizedocdiractionpeople>();
        }

        [Key]
        public int idsizedocdiraction { get; set; }
        public int? idsizedoc { get; set; }
        public int? iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
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

        [ForeignKey("iddiraction")]
        [InverseProperty("sizedocdiraction")]
        public virtual diraction? iddiractionNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("sizedocdiractionidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleedit")]
        [InverseProperty("sizedocdiractionidpeopleeditNavigation")]
        public virtual people? idpeopleeditNavigation { get; set; }
        [ForeignKey("idpeopleexec")]
        [InverseProperty("sizedocdiractionidpeopleexecNavigation")]
        public virtual people? idpeopleexecNavigation { get; set; }
        [ForeignKey("idsizedoc")]
        [InverseProperty("sizedocdiraction")]
        public virtual sizedoc? idsizedocNavigation { get; set; }
        [InverseProperty("idsizedocdiractionNavigation")]
        public virtual ICollection<sizedocdiractionpeople> sizedocdiractionpeople { get; set; }
    }
}
