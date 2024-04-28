using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class varianttype
    {
        public varianttype()
        {
            variant = new HashSet<variant>();
        }

        [Key]
        public int idvarianttype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        public byte[]? pic { get; set; }

        [InverseProperty("idvarianttypeNavigation")]
        public virtual ICollection<variant> variant { get; set; }
    }
}
