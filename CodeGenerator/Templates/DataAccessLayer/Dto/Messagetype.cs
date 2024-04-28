using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__messagetype__7E4E643D", IsUnique = true)]
    public partial class messagetype
    {
        public messagetype()
        {
            messages = new HashSet<messages>();
        }

        [Key]
        public int idmessagetype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idmessagetypeNavigation")]
        public virtual ICollection<messages> messages { get; set; }
    }
}
