using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iderror", Name = "idx_shtapikgroupdetail_iderror")]
    [Index("idgood", Name = "idx_shtapikgroupdetail_idgood")]
    [Index("idshtapikgroup", Name = "idx_shtapikgroupdetail_idshtapikgroup")]
    [Index("idworkoper", Name = "idx_shtapikgroupdetail_idworkoper")]
    public partial class shtapikgroupdetail
    {
        public shtapikgroupdetail()
        {
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
        }

        [Key]
        public int idshtapikgroupdetail { get; set; }
        [Column(TypeName = "numeric(4, 2)")]
        public decimal thick { get; set; }
        public int? idgood { get; set; }
        public int idshtapikgroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(4, 2)")]
        public decimal? thick2 { get; set; }
        public int? idworkoper { get; set; }
        public int? iderror { get; set; }

        [ForeignKey("iderror")]
        [InverseProperty("shtapikgroupdetail")]
        public virtual error? iderrorNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("shtapikgroupdetail")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idshtapikgroup")]
        [InverseProperty("shtapikgroupdetail")]
        public virtual shtapikgroup idshtapikgroupNavigation { get; set; } = null!;
        [ForeignKey("idworkoper")]
        [InverseProperty("shtapikgroupdetail")]
        public virtual workoper? idworkoperNavigation { get; set; }
        [InverseProperty("idshtapikgroupdetailNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
    }
}
