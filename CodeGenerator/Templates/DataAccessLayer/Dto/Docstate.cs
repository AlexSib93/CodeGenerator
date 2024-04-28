using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocappearance", Name = "idx_docstate_iddocappearance")]
    public partial class docstate
    {
        public docstate()
        {
            coatdoc = new HashSet<coatdoc>();
            customer = new HashSet<customer>();
            delivdoc = new HashSet<delivdoc>();
            files = new HashSet<files>();
            installdoc = new HashSet<installdoc>();
            manufactdoc = new HashSet<manufactdoc>();
            optimdoc = new HashSet<optimdoc>();
            orders = new HashSet<orders>();
            paymentdoc = new HashSet<paymentdoc>();
            pollexecuting = new HashSet<pollexecuting>();
            pricelist = new HashSet<pricelist>();
            productiondoc = new HashSet<productiondoc>();
            revisiongp = new HashSet<revisiongp>();
            servicedoc = new HashSet<servicedoc>();
            sizedoc = new HashSet<sizedoc>();
            storedoc = new HashSet<storedoc>();
            supplydoc = new HashSet<supplydoc>();
            techdoc = new HashSet<techdoc>();
        }

        [Key]
        public int iddocstate { get; set; }
        public int? iddocappearance { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public bool? beginstate { get; set; }
        public bool? endstate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddocappearance")]
        [InverseProperty("docstate")]
        public virtual docappearance? iddocappearanceNavigation { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<coatdoc> coatdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<customer> customer { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<files> files { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<manufactdoc> manufactdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<optimdoc> optimdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<pollexecuting> pollexecuting { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<productiondoc> productiondoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<revisiongp> revisiongp { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<servicedoc> servicedoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<storedoc> storedoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
        [InverseProperty("iddocstateNavigation")]
        public virtual ICollection<techdoc> techdoc { get; set; }
    }
}
