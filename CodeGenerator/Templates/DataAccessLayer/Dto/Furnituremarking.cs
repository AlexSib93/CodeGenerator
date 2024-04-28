using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__furnituremarking__2AE11392", IsUnique = true)]
    public partial class furnituremarking
    {
        [Key]
        public int idfurnituremarking { get; set; }
        public int idfurniture { get; set; }
        public bool? isactive { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? marking { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date_begin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date_end { get; set; }
    }
}
