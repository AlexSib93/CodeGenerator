using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class colorgroupcustom
    {
        public colorgroupcustom()
        {
            colorgroupprice = new HashSet<colorgroupprice>();
            good = new HashSet<good>();
            productiontype = new HashSet<productiontype>();
            productiontypesystems = new HashSet<productiontypesystems>();
        }

        [Key]
        public int idcolorgroupcustom { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [InverseProperty("idcolorgroupcustomNavigation")]
        public virtual ICollection<colorgroupprice> colorgroupprice { get; set; }
        [InverseProperty("idcolorgroupcustomNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idcolorgroupcustomNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
        [InverseProperty("idcolorgroupcustomNavigation")]
        public virtual ICollection<productiontypesystems> productiontypesystems { get; set; }
    }
}
