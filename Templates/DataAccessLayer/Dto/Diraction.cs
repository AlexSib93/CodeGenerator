using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__diraction__2879A833", IsUnique = true)]
    [Index("iddiractiongroup", Name = "idx_diraction_iddiractiongroup")]
    public partial class diraction
    {
        public diraction()
        {
            customerdiraction = new HashSet<customerdiraction>();
            delivdocdiraction = new HashSet<delivdocdiraction>();
            diractiongrant = new HashSet<diractiongrant>();
            installdocdiraction = new HashSet<installdocdiraction>();
            manufactdiraction = new HashSet<manufactdiraction>();
            optimdocdiraction = new HashSet<optimdocdiraction>();
            orderdiraction = new HashSet<orderdiraction>();
            pollexecutingdiraction = new HashSet<pollexecutingdiraction>();
            poweriddiraction1Navigation = new HashSet<power>();
            poweriddiraction2Navigation = new HashSet<power>();
            servicedocdiraction = new HashSet<servicedocdiraction>();
            sizedocdiraction = new HashSet<sizedocdiraction>();
            supplydocdiraction = new HashSet<supplydocdiraction>();
            techdocdiraction = new HashSet<techdocdiraction>();
        }

        [Key]
        public int iddiraction { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        public short? autosave { get; set; }
        public int? duration { get; set; }
        public short? autosave2 { get; set; }
        public int? iddiractiongroup { get; set; }
        public Guid guid { get; set; }
        public short? addtooptimdoc { get; set; }

        [ForeignKey("iddiractiongroup")]
        [InverseProperty("diraction")]
        public virtual diractiongroup? iddiractiongroupNavigation { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<customerdiraction> customerdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<delivdocdiraction> delivdocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<diractiongrant> diractiongrant { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<installdocdiraction> installdocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<manufactdiraction> manufactdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<optimdocdiraction> optimdocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<orderdiraction> orderdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<pollexecutingdiraction> pollexecutingdiraction { get; set; }
        [InverseProperty("iddiraction1Navigation")]
        public virtual ICollection<power> poweriddiraction1Navigation { get; set; }
        [InverseProperty("iddiraction2Navigation")]
        public virtual ICollection<power> poweriddiraction2Navigation { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<servicedocdiraction> servicedocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<sizedocdiraction> sizedocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<supplydocdiraction> supplydocdiraction { get; set; }
        [InverseProperty("iddiractionNavigation")]
        public virtual ICollection<techdocdiraction> techdocdiraction { get; set; }
    }
}
