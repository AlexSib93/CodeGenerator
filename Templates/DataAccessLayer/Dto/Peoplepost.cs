using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeoplepostgroup", Name = "idx_peoplepost_idpeoplepostgroup")]
    public partial class peoplepost
    {
        public peoplepost()
        {
            customerpeople = new HashSet<customerpeople>();
            people = new HashSet<people>();
        }

        [Key]
        public int idpeoplepost { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Ссылка на группу должностей
        /// </summary>
        public int? idpeoplepostgroup { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idpeoplepostgroup")]
        [InverseProperty("peoplepost")]
        public virtual peoplepostgroup? idpeoplepostgroupNavigation { get; set; }
        [InverseProperty("idpeoplepostNavigation")]
        public virtual ICollection<customerpeople> customerpeople { get; set; }
        [InverseProperty("idpeoplepostNavigation")]
        public virtual ICollection<people> people { get; set; }
    }
}
