using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolorgroupcustom", Name = "idx_productiontype_idcolorgroupcustom")]
    [Index("idconstructiontype", Name = "idx_productiontype_idconstructiontype")]
    [Index("idmeasure", Name = "idx_productiontype_idmeasure")]
    [Index("idpower", Name = "idx_productiontype_idpower")]
    [Index("idpricechange", Name = "idx_productiontype_idpricechange")]
    [Index("idproductiontypegroup", Name = "idx_productiontype_idproductiontypegroup")]
    public partial class productiontype
    {
        public productiontype()
        {
            modelparamcondition = new HashSet<modelparamcondition>();
            orderitem = new HashSet<orderitem>();
            pf_glass = new HashSet<pf_glass>();
            pf_ms = new HashSet<pf_ms>();
            pf_pt = new HashSet<pf_pt>();
            pf_stv = new HashSet<pf_stv>();
            pricelist = new HashSet<pricelist>();
            productiontypeconstruction = new HashSet<productiontypeconstruction>();
            productiontypegrant = new HashSet<productiontypegrant>();
            productiontypeparam = new HashSet<productiontypeparam>();
            productiontypesetting = new HashSet<productiontypesetting>();
            productiontypesystems = new HashSet<productiontypesystems>();
            productiontypetemplate = new HashSet<productiontypetemplate>();
            sizedocconstrtype = new HashSet<sizedocconstrtype>();
        }

        [Key]
        public int idproductiontype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontypegroup { get; set; }
        public byte[]? picture { get; set; }
        public Guid guid { get; set; }
        /// <summary>
        /// Ссылка на группу типов продукции
        /// </summary>
        public int? idproductiontypegroup { get; set; }
        public int? typ { get; set; }
        public int? idconstructiontype { get; set; }
        [Required]
        public bool? isactive { get; set; }
        public int? idmeasure { get; set; }
        public int? idpower { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public bool? onlytemplate { get; set; }
        public int? idpricechange { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name_strkey { get; set; }

        [ForeignKey("idcolorgroupcustom")]
        [InverseProperty("productiontype")]
        public virtual colorgroupcustom? idcolorgroupcustomNavigation { get; set; }
        [ForeignKey("idconstructiontype")]
        [InverseProperty("productiontype")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmeasure")]
        [InverseProperty("productiontype")]
        public virtual measure? idmeasureNavigation { get; set; }
        [ForeignKey("idpower")]
        [InverseProperty("productiontype")]
        public virtual power? idpowerNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("productiontype")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idproductiontypegroup")]
        [InverseProperty("productiontype")]
        public virtual productiontypegroup? idproductiontypegroupNavigation { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<modelparamcondition> modelparamcondition { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<orderitem> orderitem { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<pf_glass> pf_glass { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<pf_ms> pf_ms { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<pf_pt> pf_pt { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<pf_stv> pf_stv { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypeconstruction> productiontypeconstruction { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypegrant> productiontypegrant { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypeparam> productiontypeparam { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypesetting> productiontypesetting { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypesystems> productiontypesystems { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<productiontypetemplate> productiontypetemplate { get; set; }
        [InverseProperty("idproductiontypeNavigation")]
        public virtual ICollection<sizedocconstrtype> sizedocconstrtype { get; set; }
    }
}
