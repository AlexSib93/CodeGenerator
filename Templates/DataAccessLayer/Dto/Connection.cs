using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idsystemdetail1", Name = "idx_connection_idsystemdetail1")]
    [Index("idsystemdetail2", Name = "idx_connection_idsystemdetail2")]
    [Index("parentid", Name = "idx_connection_parentid")]
    public partial class connection
    {
        public connection()
        {
            variant = new HashSet<variant>();
        }

        [Key]
        public int idconnection { get; set; }
        public int? idsystemdetail1 { get; set; }
        public int? idsystemdetail2 { get; set; }
        public int? numpos { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? parentid { get; set; }

        [ForeignKey("idsystemdetail1")]
        [InverseProperty("connectionidsystemdetail1Navigation")]
        public virtual systemdetail? idsystemdetail1Navigation { get; set; }
        [ForeignKey("idsystemdetail2")]
        [InverseProperty("connectionidsystemdetail2Navigation")]
        public virtual systemdetail? idsystemdetail2Navigation { get; set; }
        [InverseProperty("idconnectionNavigation")]
        public virtual ICollection<variant> variant { get; set; }
    }
}
