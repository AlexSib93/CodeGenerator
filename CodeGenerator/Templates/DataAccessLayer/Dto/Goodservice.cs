using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodservice__6D23D83B", IsUnique = true)]
    [Index("idgoodservicegroup", Name = "idx_goodservice_idgoodservicegroup")]
    [Index("idvalut1", Name = "idx_goodservice_idvalut1")]
    [Index("idvalut2", Name = "idx_goodservice_idvalut2")]
    [Index("idvalut3", Name = "idx_goodservice_idvalut3")]
    [Index("idvalut4", Name = "idx_goodservice_idvalut4")]
    [Index("idvalut5", Name = "idx_goodservice_idvalut5")]
    public partial class goodservice
    {
        public goodservice()
        {
            installdocgoodservice = new HashSet<installdocgoodservice>();
            ordergoodservice = new HashSet<ordergoodservice>();
            pricelistgoodservice = new HashSet<pricelistgoodservice>();
            supplydocgoodservice = new HashSet<supplydocgoodservice>();
        }

        [Key]
        public int idgoodservice { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodservicegroup { get; set; }
        public short? isperc { get; set; }
        public int? idgoodservicegroup { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        public int? idvalut1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public int? idvalut2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        public int? idvalut3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        public int? idvalut4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public int? idvalut5 { get; set; }
        /// <summary>
        /// Своя услуга
        /// </summary>
        public bool? ismy { get; set; }

        [ForeignKey("idgoodservicegroup")]
        [InverseProperty("goodservice")]
        public virtual goodservicegroup? idgoodservicegroupNavigation { get; set; }
        [ForeignKey("idvalut1")]
        [InverseProperty("goodserviceidvalut1Navigation")]
        public virtual valut? idvalut1Navigation { get; set; }
        [ForeignKey("idvalut2")]
        [InverseProperty("goodserviceidvalut2Navigation")]
        public virtual valut? idvalut2Navigation { get; set; }
        [ForeignKey("idvalut3")]
        [InverseProperty("goodserviceidvalut3Navigation")]
        public virtual valut? idvalut3Navigation { get; set; }
        [ForeignKey("idvalut4")]
        [InverseProperty("goodserviceidvalut4Navigation")]
        public virtual valut? idvalut4Navigation { get; set; }
        [ForeignKey("idvalut5")]
        [InverseProperty("goodserviceidvalut5Navigation")]
        public virtual valut? idvalut5Navigation { get; set; }
        [InverseProperty("idgoodserviceNavigation")]
        public virtual ICollection<installdocgoodservice> installdocgoodservice { get; set; }
        [InverseProperty("idgoodserviceNavigation")]
        public virtual ICollection<ordergoodservice> ordergoodservice { get; set; }
        [InverseProperty("idgoodserviceNavigation")]
        public virtual ICollection<pricelistgoodservice> pricelistgoodservice { get; set; }
        [InverseProperty("idgoodserviceNavigation")]
        public virtual ICollection<supplydocgoodservice> supplydocgoodservice { get; set; }
    }
}
