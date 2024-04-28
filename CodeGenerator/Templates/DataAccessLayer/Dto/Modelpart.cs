using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__modelpart__3203126D", IsUnique = true)]
    [Index("idmodelpartroot", Name = "idx_modelpart_idmodelpartroot")]
    [Index("idversion", Name = "idx_modelpart_idversion")]
    [Index("parentid", Name = "idx_modelpart_parentid")]
    public partial class modelpart
    {
        public modelpart()
        {
            constructiontypedetail = new HashSet<constructiontypedetail>();
            modelparam = new HashSet<modelparam>();
            modelparamcalc = new HashSet<modelparamcalc>();
            modelscript = new HashSet<modelscript>();
            systemdetail = new HashSet<systemdetail>();
            templateparam = new HashSet<templateparam>();
        }

        [Key]
        public int idmodelpart { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public int? typ { get; set; }
        public int? numpos { get; set; }
        public int? idversion { get; set; }
        public int? idmodelpartroot { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idversion")]
        [InverseProperty("modelpart")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<constructiontypedetail> constructiontypedetail { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<modelparam> modelparam { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<modelparamcalc> modelparamcalc { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<modelscript> modelscript { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<systemdetail> systemdetail { get; set; }
        [InverseProperty("idmodelpartNavigation")]
        public virtual ICollection<templateparam> templateparam { get; set; }
    }
}
