using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_peopleparam_idpeople")]
    [Index("idpeopleparamtype", Name = "idx_peopleparam_idpeopleparamtype")]
    public partial class peopleparam
    {
        [Key]
        public int idpeopleparam { get; set; }
        public int? idpeopleparamtype { get; set; }
        public int? idpeople { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool? indealerbase { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("peopleparam")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeopleparamtype")]
        [InverseProperty("peopleparam")]
        public virtual peopleparamtype? idpeopleparamtypeNavigation { get; set; }
    }
}
