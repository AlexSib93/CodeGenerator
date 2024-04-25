using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", Name = "idx_model_idorder")]
    [Index("idorderitem", Name = "idx_model_idorderitem")]
    public partial class model
    {
        public model()
        {
            finparamcalc = new HashSet<finparamcalc>();
            installdocpos = new HashSet<installdocpos>();
            modelcalc = new HashSet<modelcalc>();
            modelparamcalc = new HashSet<modelparamcalc>();
            modelpic = new HashSet<modelpic>();
            ordersetting = new HashSet<ordersetting>();
            productiondocpos = new HashSet<productiondocpos>();
            supplydocpos = new HashSet<supplydocpos>();
            techdocpos = new HashSet<techdocpos>();
        }

        [Key]
        public int idmodel { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public byte[]? classnative { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? idconstruction { get; set; }

        [ForeignKey("idorder")]
        [InverseProperty("model")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("model")]
        public virtual orderitem? idorderitemNavigation { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<finparamcalc> finparamcalc { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<installdocpos> installdocpos { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<modelcalc> modelcalc { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<modelparamcalc> modelparamcalc { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<modelpic> modelpic { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<ordersetting> ordersetting { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<productiondocpos> productiondocpos { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<supplydocpos> supplydocpos { get; set; }
        [InverseProperty("idmodelNavigation")]
        public virtual ICollection<techdocpos> techdocpos { get; set; }
    }
}
