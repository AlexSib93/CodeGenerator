using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class businesshours
    {
        public businesshours()
        {
            businesshoursdetail = new HashSet<businesshoursdetail>();
        }

        [Key]
        public int idbusinesshours { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string name { get; set; } = null!;

        [InverseProperty("idbusinesshoursNavigation")]
        public virtual ICollection<businesshoursdetail> businesshoursdetail { get; set; }
    }
}
