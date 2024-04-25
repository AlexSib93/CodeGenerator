using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class peopleparamtype
    {
        public peopleparamtype()
        {
            peopleparam = new HashSet<peopleparam>();
        }

        [Key]
        public int idpeopleparamtype { get; set; }
        [StringLength(50)]
        public string? code { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idpeopleparamtypeNavigation")]
        public virtual ICollection<peopleparam> peopleparam { get; set; }
    }
}
