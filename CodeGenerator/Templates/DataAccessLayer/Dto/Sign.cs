using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__sign__414555FD", IsUnique = true)]
    [Index("idsigngroup", Name = "idx_sign_idsigngroup")]
    public partial class sign
    {
        public sign()
        {
            coatdocsign = new HashSet<coatdocsign>();
            customersign = new HashSet<customersign>();
            delivdocsign = new HashSet<delivdocsign>();
            installdocsign = new HashSet<installdocsign>();
            manufactdocsign = new HashSet<manufactdocsign>();
            optimdocsign = new HashSet<optimdocsign>();
            ordersign = new HashSet<ordersign>();
            paymentdocsign = new HashSet<paymentdocsign>();
            pollexecutingsign = new HashSet<pollexecutingsign>();
            productiondocsign = new HashSet<productiondocsign>();
            servicedocsign = new HashSet<servicedocsign>();
            signgrant = new HashSet<signgrant>();
            signvalue = new HashSet<signvalue>();
            storedocsign = new HashSet<storedocsign>();
            supplydocsign = new HashSet<supplydocsign>();
            techdocsign = new HashSet<techdocsign>();
        }

        [Key]
        public int idsign { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idsigngroup { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idsigngroup")]
        [InverseProperty("sign")]
        public virtual signgroup? idsigngroupNavigation { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<coatdocsign> coatdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<customersign> customersign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<delivdocsign> delivdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<installdocsign> installdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<manufactdocsign> manufactdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<optimdocsign> optimdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<ordersign> ordersign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<paymentdocsign> paymentdocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<pollexecutingsign> pollexecutingsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<productiondocsign> productiondocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<servicedocsign> servicedocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<signgrant> signgrant { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<signvalue> signvalue { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<storedocsign> storedocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<supplydocsign> supplydocsign { get; set; }
        [InverseProperty("idsignNavigation")]
        public virtual ICollection<techdocsign> techdocsign { get; set; }
    }
}
