using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__furnituregoodkit__271082AE", IsUnique = true)]
    public partial class furnituregoodkit
    {
        [Key]
        public int idfurnituregoodkit { get; set; }
        public int? idfurniture { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date_begin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date_end { get; set; }
        public bool? isactive { get; set; }
        public int? idgoodkit { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
    }
}
