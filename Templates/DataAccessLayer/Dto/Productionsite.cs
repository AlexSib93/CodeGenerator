using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class productionsite
    {
        public productionsite()
        {
            car = new HashSet<car>();
            destanation = new HashSet<destanation>();
            docoper = new HashSet<docoper>();
            power = new HashSet<power>();
            pyramid = new HashSet<pyramid>();
            route = new HashSet<route>();
            storedepart = new HashSet<storedepart>();
        }

        [Key]
        public int idproductionsite { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<car> car { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<destanation> destanation { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<docoper> docoper { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<power> power { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<pyramid> pyramid { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<route> route { get; set; }
        [InverseProperty("idproductionsiteNavigation")]
        public virtual ICollection<storedepart> storedepart { get; set; }
    }
}
