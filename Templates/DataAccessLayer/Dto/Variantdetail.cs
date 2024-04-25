using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iderror", Name = "idx_variantdetail_iderror")]
    [Index("idgood", Name = "idx_variantdetail_idgood")]
    [Index("idvariant", Name = "idx_variantdetail_idvariant")]
    [Index("idworkoper", Name = "idx_variantdetail_idworkoper")]
    public partial class variantdetail
    {
        public variantdetail()
        {
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idvariantdetail { get; set; }
        public int? idgood { get; set; }
        public int? idvariant { get; set; }
        public int? idworkoper { get; set; }
        public int? iderror { get; set; }

        [ForeignKey("iderror")]
        [InverseProperty("variantdetail")]
        public virtual error? iderrorNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("variantdetail")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idvariant")]
        [InverseProperty("variantdetail")]
        public virtual variant? idvariantNavigation { get; set; }
        [ForeignKey("idworkoper")]
        [InverseProperty("variantdetail")]
        public virtual workoper? idworkoperNavigation { get; set; }
        [InverseProperty("idvariantdetailNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
