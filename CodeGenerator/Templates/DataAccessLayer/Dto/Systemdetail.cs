using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__systemdetail__6B3B8FC9", IsUnique = true)]
    [Index("idconnectortype", Name = "idx_systemdetail_idconnectortype")]
    [Index("idmodelpart", Name = "idx_systemdetail_idmodelpart")]
    [Index("idsystem", Name = "idx_systemdetail_idsystem")]
    [Index("idversion", Name = "idx_systemdetail_idversion")]
    [Index("width", Name = "idx_systemdetail_width")]
    public partial class systemdetail
    {
        public systemdetail()
        {
            connectionidsystemdetail1Navigation = new HashSet<connection>();
            connectionidsystemdetail2Navigation = new HashSet<connection>();
            constructiontypedetail = new HashSet<constructiontypedetail>();
            insertion = new HashSet<insertion>();
            insertionparam = new HashSet<insertionparam>();
            insertionparamdetail = new HashSet<insertionparamdetail>();
            modelparamcondition = new HashSet<modelparamcondition>();
            pf_pt = new HashSet<pf_pt>();
            shtapikgroupprofile = new HashSet<shtapikgroupprofile>();
            systemdetailrelationshipidsystemdetail1Navigation = new HashSet<systemdetailrelationship>();
            systemdetailrelationshipidsystemdetail2Navigation = new HashSet<systemdetailrelationship>();
            systemdetailrelidsystemdetail2Navigation = new HashSet<systemdetailrel>();
            systemdetailrelidsystemdetailNavigation = new HashSet<systemdetailrel>();
        }

        [Key]
        public int idsystemdetail { get; set; }
        public int? idsystem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? a { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? b { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? c { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? d { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? e { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? g { get; set; }
        public int? thick { get; set; }
        public int? thickness { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? weight { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? idmodelpart { get; set; }
        public int? idversion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? systemdetailgroup { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? steel { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minang { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxang { get; set; }
        public int? minr { get; set; }
        public int? maxr { get; set; }
        /// <summary>
        /// Ламинация внутренняя
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr1 { get; set; }
        /// <summary>
        /// Ламинация внешняя
        /// </summary>
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? z { get; set; }
        public byte[]? profilesection { get; set; }
        public Guid guid { get; set; }
        public int? idconnectortype { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? a1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? b1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? c1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? d1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? e1 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? a2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? b2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? c2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? d2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? e2 { get; set; }
        public int? israck { get; set; }
        public bool? israil { get; set; }

        [ForeignKey("idconnectortype")]
        [InverseProperty("systemdetail")]
        public virtual connectortype? idconnectortypeNavigation { get; set; }
        [ForeignKey("idmodelpart")]
        [InverseProperty("systemdetail")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
        [ForeignKey("idsystem")]
        [InverseProperty("systemdetail")]
        public virtual system? idsystemNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("systemdetail")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idsystemdetail1Navigation")]
        public virtual ICollection<connection> connectionidsystemdetail1Navigation { get; set; }
        [InverseProperty("idsystemdetail2Navigation")]
        public virtual ICollection<connection> connectionidsystemdetail2Navigation { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<constructiontypedetail> constructiontypedetail { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<insertion> insertion { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<insertionparam> insertionparam { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<pf_pt> pf_pt { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<shtapikgroupprofile> shtapikgroupprofile { get; set; }
        [InverseProperty("idsystemdetail1Navigation")]
        public virtual ICollection<systemdetailrelationship> systemdetailrelationshipidsystemdetail1Navigation { get; set; }
        [InverseProperty("idsystemdetail2Navigation")]
        public virtual ICollection<systemdetailrelationship> systemdetailrelationshipidsystemdetail2Navigation { get; set; }
        [InverseProperty("idsystemdetail2Navigation")]
        public virtual ICollection<systemdetailrel> systemdetailrelidsystemdetail2Navigation { get; set; }
        [InverseProperty("idsystemdetailNavigation")]
        public virtual ICollection<systemdetailrel> systemdetailrelidsystemdetailNavigation { get; set; }
    }
}
