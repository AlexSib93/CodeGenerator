using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__constructiontype__5FC9DD1D", IsUnique = true)]
    [Index("idconstructiontype", Name = "idx_constructiontypedetail_idconstructiontype")]
    [Index("idmodelpart", Name = "idx_constructiontypedetail_idmodelpart")]
    [Index("idsystem", Name = "idx_constructiontypedetail_idsystem")]
    [Index("idsystemdetail", Name = "idx_constructiontypedetail_idsystemdetail")]
    [Index("idversion", Name = "idx_constructiontypedetail_idversion")]
    public partial class constructiontypedetail
    {
        [Key]
        public int idconstructiontypedetail { get; set; }
        public int? idversion { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idsystem { get; set; }
        public int? idsystemdetail { get; set; }
        public int? numpos { get; set; }
        public int? idmodelpart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public bool? alsoimpost { get; set; }
        public bool? isactive { get; set; }
        [Column("using")]
        public byte? _using { get; set; }

        [ForeignKey("idconstructiontype")]
        [InverseProperty("constructiontypedetail")]
        public virtual constructiontype? idconstructiontypeNavigation { get; set; }
        [ForeignKey("idmodelpart")]
        [InverseProperty("constructiontypedetail")]
        public virtual modelpart? idmodelpartNavigation { get; set; }
        [ForeignKey("idsystem")]
        [InverseProperty("constructiontypedetail")]
        public virtual system? idsystemNavigation { get; set; }
        [ForeignKey("idsystemdetail")]
        [InverseProperty("constructiontypedetail")]
        public virtual systemdetail? idsystemdetailNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("constructiontypedetail")]
        public virtual versions? idversionNavigation { get; set; }
    }
}
