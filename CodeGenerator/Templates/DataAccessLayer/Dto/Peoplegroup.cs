using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_peoplegroup_parentid")]
    public partial class peoplegroup
    {
        public peoplegroup()
        {
            agreementgrant = new HashSet<agreementgrant>();
            diractiongrant = new HashSet<diractiongrant>();
            docopergrant = new HashSet<docopergrant>();
            docscriptgrant = new HashSet<docscriptgrant>();
            peoplegrouplist = new HashSet<peoplegrouplist>();
            powergrant = new HashSet<powergrant>();
            pricechangegrant = new HashSet<pricechangegrant>();
            productiontypegrant = new HashSet<productiontypegrant>();
            reportdocoper = new HashSet<reportdocoper>();
            signgrant = new HashSet<signgrant>();
        }

        [Key]
        public int idpeoplegroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public byte[]? grants { get; set; }
        public int? addint { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? addstr { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        public Guid guid { get; set; }

        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<agreementgrant> agreementgrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<diractiongrant> diractiongrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<docopergrant> docopergrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<docscriptgrant> docscriptgrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<peoplegrouplist> peoplegrouplist { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<powergrant> powergrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<pricechangegrant> pricechangegrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<productiontypegrant> productiontypegrant { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<reportdocoper> reportdocoper { get; set; }
        [InverseProperty("idpeoplegroupNavigation")]
        public virtual ICollection<signgrant> signgrant { get; set; }
    }
}
