using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__ordereventgroup__48E677C5", IsUnique = true)]
    public partial class ordereventgroup
    {
        public ordereventgroup()
        {
            orderevent = new HashSet<orderevent>();
        }

        [Key]
        public int idordereventgroup { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idordereventgroupNavigation")]
        public virtual ICollection<orderevent> orderevent { get; set; }
    }
}
