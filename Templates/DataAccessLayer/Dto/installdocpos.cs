using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgood", Name = "idx_installdocpos_idgood")]
    [Index("idinstalldoc", Name = "idx_installdocpos_idinstalldoc")]
    [Index("idmodel", Name = "idx_installdocpos_idmodel")]
    [Index("idorderitem", Name = "idx_installdocpos_idorderitem")]
    [Index("width", Name = "idx_installdocpos_width")]
    public partial class installdocpos
    {
        public installdocpos()
        {
            installdocgoodservice = new HashSet<installdocgoodservice>();
        }

        [Key]
        public int idinstalldocpos { get; set; }
        public int? idinstalldoc { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? thick { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("installdocpos")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idinstalldoc")]
        [InverseProperty("installdocpos")]
        public virtual installdoc? idinstalldocNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("installdocpos")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("installdocpos")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [InverseProperty("idinstalldocposNavigation")]
        public virtual ICollection<installdocgoodservice> installdocgoodservice { get; set; }
    }
}
