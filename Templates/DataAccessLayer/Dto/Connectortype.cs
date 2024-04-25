using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class connectortype
    {
        public connectortype()
        {
            systemdetail = new HashSet<systemdetail>();
        }

        [Key]
        public int idconnectortype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idconnectortypeNavigation")]
        public virtual ICollection<systemdetail> systemdetail { get; set; }
    }
}
