using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ_route_guid", IsUnique = true)]
    [Index("idproductionsite", Name = "idx_route_idproductionsite")]
    public partial class route
    {
        public route()
        {
            carmarkingroute = new HashSet<carmarkingroute>();
            destanation = new HashSet<destanation>();
            destanationroute = new HashSet<destanationroute>();
        }

        [Key]
        public int idroute { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public short? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpreference { get; set; }
        public int? grouping { get; set; }
        public Guid guid { get; set; }
        public int? transit { get; set; }
        public int? maxpyr { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? maxpyrgroup { get; set; }
        public bool? active { get; set; }
        public bool? autouse { get; set; }
        public int? idproductionsite { get; set; }

        [ForeignKey("idproductionsite")]
        [InverseProperty("route")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [InverseProperty("idrouteNavigation")]
        public virtual ICollection<carmarkingroute> carmarkingroute { get; set; }
        [InverseProperty("idrouteNavigation")]
        public virtual ICollection<destanation> destanation { get; set; }
        [InverseProperty("idrouteNavigation")]
        public virtual ICollection<destanationroute> destanationroute { get; set; }
    }
}
