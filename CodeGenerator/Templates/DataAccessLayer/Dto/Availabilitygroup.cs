using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class availabilitygroup
    {
        public availabilitygroup()
        {
            storedepart = new HashSet<storedepart>();
        }

        [Key]
        public int idavailabilitygroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idavailabilitygroupNavigation")]
        public virtual ICollection<storedepart> storedepart { get; set; }
    }
}
