using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction1", Name = "idx_power_iddiraction1")]
    [Index("iddiraction2", Name = "idx_power_iddiraction2")]
    [Index("iddocoper", Name = "idx_power_iddocoper")]
    [Index("idfinparam", Name = "idx_power_idfinparam")]
    [Index("idganttchart", Name = "idx_power_idganttchart")]
    [Index("idproductionsite", Name = "idx_power_idproductionsite")]
    [Index("parentid", Name = "idx_power_parentid")]
    public partial class power
    {
        public power()
        {
            orderitem = new HashSet<orderitem>();
            powergrant = new HashSet<powergrant>();
            powerplan = new HashSet<powerplan>();
            powerrelidpowermasterNavigation = new HashSet<powerrel>();
            powerrelidpowerslaveNavigation = new HashSet<powerrel>();
            productiontype = new HashSet<productiontype>();
            respower = new HashSet<respower>();
        }

        [Key]
        public int idpower { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxval { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? powergroup { get; set; }
        public Guid guid { get; set; }
        public bool checkpower { get; set; }
        public int duration { get; set; }
        public int? idproductionsite { get; set; }
        [Unicode(false)]
        public string? model { get; set; }
        public int? iddiraction1 { get; set; }
        public int? iddiraction2 { get; set; }
        public int? idfinparam { get; set; }
        public int? parentid { get; set; }
        public int? idganttchart { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? limit { get; set; }
        public bool? need_more_precise { get; set; }

        [ForeignKey("iddiraction1")]
        [InverseProperty("poweriddiraction1Navigation")]
        public virtual diraction? iddiraction1Navigation { get; set; }
        [ForeignKey("iddiraction2")]
        [InverseProperty("poweriddiraction2Navigation")]
        public virtual diraction? iddiraction2Navigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("power")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idfinparam")]
        [InverseProperty("power")]
        public virtual finparam? idfinparamNavigation { get; set; }
        [ForeignKey("idganttchart")]
        [InverseProperty("power")]
        public virtual ganttchart? idganttchartNavigation { get; set; }
        [ForeignKey("idproductionsite")]
        [InverseProperty("power")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [InverseProperty("idpowerNavigation")]
        public virtual ICollection<orderitem> orderitem { get; set; }
        [InverseProperty("idpowerNavigation")]
        public virtual ICollection<powergrant> powergrant { get; set; }
        [InverseProperty("idpowerNavigation")]
        public virtual ICollection<powerplan> powerplan { get; set; }
        [InverseProperty("idpowermasterNavigation")]
        public virtual ICollection<powerrel> powerrelidpowermasterNavigation { get; set; }
        [InverseProperty("idpowerslaveNavigation")]
        public virtual ICollection<powerrel> powerrelidpowerslaveNavigation { get; set; }
        [InverseProperty("idpowerNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
        [InverseProperty("idpowerNavigation")]
        public virtual ICollection<respower> respower { get; set; }
    }
}
