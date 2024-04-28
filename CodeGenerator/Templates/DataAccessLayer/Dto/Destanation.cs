using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__destanation__0D90A7CD", IsUnique = true)]
    [Index("idpreference", Name = "idx_destanation_idpreference")]
    [Index("idproductionsite", Name = "idx_destanation_idproductionsite")]
    [Index("idpyramid", Name = "idx_destanation_idpyramid")]
    [Index("idroute", Name = "idx_destanation_idroute")]
    public partial class destanation
    {
        public destanation()
        {
            alu_cityregion = new HashSet<alu_cityregion>();
            customerdestanation = new HashSet<customerdestanation>();
            delivdoc = new HashSet<delivdoc>();
            destanationcustomer = new HashSet<destanationcustomer>();
            destanationplan = new HashSet<destanationplan>();
            destanationroute = new HashSet<destanationroute>();
            destanationseller = new HashSet<destanationseller>();
            installdoc = new HashSet<installdoc>();
            orders = new HashSet<orders>();
            sellerdestanation = new HashSet<sellerdestanation>();
            servicedoc = new HashSet<servicedoc>();
            sizedoc = new HashSet<sizedoc>();
        }

        [Key]
        public int iddestanation { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanationgroup { get; set; }
        public int? idpyramid { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        public int? idroute { get; set; }
        public int? idpreference { get; set; }
        public int? pyrgrouping { get; set; }
        public int? transit { get; set; }
        public int? maxpyr { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? factory { get; set; }
        public int? pyrgroup { get; set; }
        public int? idproductionsite { get; set; }

        [ForeignKey("idpreference")]
        [InverseProperty("destanation")]
        public virtual preference? idpreferenceNavigation { get; set; }
        [ForeignKey("idproductionsite")]
        [InverseProperty("destanation")]
        public virtual productionsite? idproductionsiteNavigation { get; set; }
        [ForeignKey("idpyramid")]
        [InverseProperty("destanation")]
        public virtual pyramid? idpyram { get; set; }
        [ForeignKey("idroute")]
        [InverseProperty("destanation")]
        public virtual route? idrouteNavigation { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<alu_cityregion> alu_cityregion { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<customerdestanation> customerdestanation { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<destanationcustomer> destanationcustomer { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<destanationplan> destanationplan { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<destanationroute> destanationroute { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<destanationseller> destanationseller { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<sellerdestanation> sellerdestanation { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<servicedoc> servicedoc { get; set; }
        [InverseProperty("iddestanationNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
    }
}
