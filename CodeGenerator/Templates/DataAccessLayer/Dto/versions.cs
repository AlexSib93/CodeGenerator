using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__versions__432D9E6F", IsUnique = true)]
    public partial class versions
    {
        public versions()
        {
            constructiontype = new HashSet<constructiontype>();
            constructiontypedetail = new HashSet<constructiontypedetail>();
            modelparam = new HashSet<modelparam>();
            modelpart = new HashSet<modelpart>();
            modelscript = new HashSet<modelscript>();
            orderitem = new HashSet<orderitem>();
            orders = new HashSet<orders>();
            pricelist = new HashSet<pricelist>();
            system = new HashSet<system>();
            systemdetail = new HashSet<systemdetail>();
            systemdetailrel = new HashSet<systemdetailrel>();
        }

        [Key]
        public int idversion { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? versiondate { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? versiongroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? versiondate2 { get; set; }
        public short? typ { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? serial { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idversionNavigation")]
        public virtual ICollection<constructiontype> constructiontype { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<constructiontypedetail> constructiontypedetail { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<modelparam> modelparam { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<modelpart> modelpart { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<modelscript> modelscript { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<orderitem> orderitem { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<system> system { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<systemdetail> systemdetail { get; set; }
        [InverseProperty("idversionNavigation")]
        public virtual ICollection<systemdetailrel> systemdetailrel { get; set; }
    }
}
