using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idtemplategroup", Name = "idx_template_idtemplategroup")]
    public partial class template
    {
        public template()
        {
            templateparam = new HashSet<templateparam>();
        }

        [Key]
        public int idtemplate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idtemplategroup { get; set; }
        public byte[]? classnative { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        /// <summary>
        /// Тип продукции
        /// </summary>
        public int? idproductiontype { get; set; }
        public int? idprofilesystem { get; set; }
        public int? idfurnituresystem { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? templatetype { get; set; }
        public int? idparent { get; set; }

        [ForeignKey("idtemplategroup")]
        [InverseProperty("template")]
        public virtual templategroup? idtemplategroupNavigation { get; set; }
        [InverseProperty("idtemplateNavigation")]
        public virtual ICollection<templateparam> templateparam { get; set; }
    }
}
