using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__color__526FE1FF", IsUnique = true)]
    [Index("idcolorgroup", Name = "idx_color_idcolorgroup")]
    public partial class color
    {
        public color()
        {
            coloraccordance = new HashSet<coloraccordance>();
            coloraccordancedetailidcolordestNavigation = new HashSet<coloraccordancedetail>();
            coloraccordancedetailidcolorsource2Navigation = new HashSet<coloraccordancedetail>();
            coloraccordancedetailidcolorsourceNavigation = new HashSet<coloraccordancedetail>();
            colorgrouppriceitemidcolor1Navigation = new HashSet<colorgrouppriceitem>();
            colorgrouppriceitemidcolor2Navigation = new HashSet<colorgrouppriceitem>();
            goodanalogidcolor1Navigation = new HashSet<goodanalog>();
            goodanalogidcolor2Navigation = new HashSet<goodanalog>();
            goodcolorparamidcolor1Navigation = new HashSet<goodcolorparam>();
            goodcolorparamidcolor2Navigation = new HashSet<goodcolorparam>();
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparam = new HashSet<modelparam>();
            modelparamcondition = new HashSet<modelparamcondition>();
            orderitemidcolorinNavigation = new HashSet<orderitem>();
            orderitemidcoloroutNavigation = new HashSet<orderitem>();
            pf_glassidcolor1Navigation = new HashSet<pf_glass>();
            pf_glassidcolor2Navigation = new HashSet<pf_glass>();
            pf_msidcolor1Navigation = new HashSet<pf_ms>();
            pf_msidcolor2Navigation = new HashSet<pf_ms>();
            shtapikgroupparamdetail = new HashSet<shtapikgroupparamdetail>();
            storedocposidcolor1Navigation = new HashSet<storedocpos>();
            storedocposidcolor2Navigation = new HashSet<storedocpos>();
            variantparam = new HashSet<variantparam>();
            variantparamdetail = new HashSet<variantparamdetail>();
        }

        [Key]
        public int idcolor { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column("color")]
        public int? color1 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroup { get; set; }
        public short? windraw { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public int? idcolorgroup { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue5 { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? outername { get; set; }
        [StringLength(64)]
        public string? name_strkey { get; set; }
        [StringLength(32)]
        public string? shortname_strkey { get; set; }

        [ForeignKey("idcolorgroup")]
        [InverseProperty("color")]
        public virtual colorgroup? idcolorgroupNavigation { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<coloraccordance> coloraccordance { get; set; }
        [InverseProperty("idcolordestNavigation")]
        public virtual ICollection<coloraccordancedetail> coloraccordancedetailidcolordestNavigation { get; set; }
        [InverseProperty("idcolorsource2Navigation")]
        public virtual ICollection<coloraccordancedetail> coloraccordancedetailidcolorsource2Navigation { get; set; }
        [InverseProperty("idcolorsourceNavigation")]
        public virtual ICollection<coloraccordancedetail> coloraccordancedetailidcolorsourceNavigation { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<colorgrouppriceitem> colorgrouppriceitemidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<colorgrouppriceitem> colorgrouppriceitemidcolor2Navigation { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<goodanalog> goodanalogidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<goodanalog> goodanalogidcolor2Navigation { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<goodcolorparam> goodcolorparamidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<goodcolorparam> goodcolorparamidcolor2Navigation { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<modelparam> modelparam { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idcolorinNavigation")]
        public virtual ICollection<orderitem> orderitemidcolorinNavigation { get; set; }
        [InverseProperty("idcoloroutNavigation")]
        public virtual ICollection<orderitem> orderitemidcoloroutNavigation { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<pf_glass> pf_glassidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<pf_glass> pf_glassidcolor2Navigation { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<pf_ms> pf_msidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<pf_ms> pf_msidcolor2Navigation { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<shtapikgroupparamdetail> shtapikgroupparamdetail { get; set; }
        [InverseProperty("idcolor1Navigation")]
        public virtual ICollection<storedocpos> storedocposidcolor1Navigation { get; set; }
        [InverseProperty("idcolor2Navigation")]
        public virtual ICollection<storedocpos> storedocposidcolor2Navigation { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<variantparam> variantparam { get; set; }
        [InverseProperty("idcolorNavigation")]
        public virtual ICollection<variantparamdetail> variantparamdetail { get; set; }
    }
}
