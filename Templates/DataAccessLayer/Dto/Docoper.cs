using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__docoper__2A61F0A5", IsUnique = true)]
    [Index("idproductionsite", Name = "idx_docoper_idproductionsite")]
    [Index("iddocappearance", Name = "jkkknj")]
    public partial class docoper
    {
        public docoper()
        {
            coatdoc = new HashSet<coatdoc>();
            customer = new HashSet<customer>();
            delivdoc = new HashSet<delivdoc>();
            diractiongrant = new HashSet<diractiongrant>();
            doclock = new HashSet<doclock>();
            docopergrant = new HashSet<docopergrant>();
            installdoc = new HashSet<installdoc>();
            manufactdoc = new HashSet<manufactdoc>();
            optimdoc = new HashSet<optimdoc>();
            orders = new HashSet<orders>();
            paymentdoc = new HashSet<paymentdoc>();
            pollexecuting = new HashSet<pollexecuting>();
            power = new HashSet<power>();
            pricelist = new HashSet<pricelist>();
            productiondoc = new HashSet<productiondoc>();
            reportdocoper = new HashSet<reportdocoper>();
            revisiongp = new HashSet<revisiongp>();
            signgrant = new HashSet<signgrant>();
            sizedoc = new HashSet<sizedoc>();
            storedepartdocoper = new HashSet<storedepartdocoper>();
            storedoc = new HashSet<storedoc>();
            supplydoc = new HashSet<supplydoc>();
            techdoc = new HashSet<techdoc>();
        }

        [Key]
        public int iddocoper { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? prefix { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? suffix { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docgroup { get; set; }
        public int? iddocappearance { get; set; }
        public int? agreenumpos { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? agreeprefix { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? agreesuffix { get; set; }
        public short? storetyp { get; set; }
        public Guid guid { get; set; }
        public int? addint { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        public int? idproductionsite { get; set; }

        [ForeignKey("idproductionsite")]
        [InverseProperty("docoper")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<coatdoc> coatdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<customer> customer { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<diractiongrant> diractiongrant { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<doclock> doclock { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<docopergrant> docopergrant { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<manufactdoc> manufactdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<pollexecuting> pollexecuting { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<power> power { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<productiondoc> productiondoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<reportdocoper> reportdocoper { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<revisiongp> revisiongp { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<signgrant> signgrant { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<storedepartdocoper> storedepartdocoper { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<storedoc> storedoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
        [InverseProperty("iddocoperNavigation")]
        public virtual ICollection<techdoc> techdoc { get; set; }
    }
}
