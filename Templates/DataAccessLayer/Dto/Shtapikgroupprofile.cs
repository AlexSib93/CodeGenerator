using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idinsertion", Name = "idx_shtapikgroupprofile_idinsertion")]
    [Index("idshtapikgroup", Name = "idx_shtapikgroupprofile_idshtapikgroup")]
    [Index("idsystemdetail", Name = "idx_shtapikgroupprofile_idsystemdetail")]
    public partial class shtapikgroupprofile
    {
        [Key]
        public int idshtapikgroupprofile { get; set; }
        public int idshtapikgroup { get; set; }
        public int? idsystemdetail { get; set; }
        [Column(TypeName = "numeric(6, 2)")]
        public decimal? size { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idinsertion { get; set; }

        [ForeignKey("idinsertion")]
        [InverseProperty("shtapikgroupprofile")]
        public virtual insertion? idinsertionNavigation { get; set; }
        [ForeignKey("idshtapikgroup")]
        [InverseProperty("shtapikgroupprofile")]
        public virtual shtapikgroup idshtapikgroupNavigation { get; set; } = null!;
        [ForeignKey("idsystemdetail")]
        [InverseProperty("shtapikgroupprofile")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
    }
}
