using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_pollexecuting_idcustomer")]
    [Index("idcustomer2", Name = "idx_pollexecuting_idcustomer2")]
    [Index("iddocoper", Name = "idx_pollexecuting_iddocoper")]
    [Index("iddocstate", Name = "idx_pollexecuting_iddocstate")]
    [Index("idorder", Name = "idx_pollexecuting_idorder")]
    [Index("idpeople", Name = "idx_pollexecuting_idpeople")]
    [Index("idpeoplecreate", Name = "idx_pollexecuting_idpeoplecreate")]
    [Index("idpoll", Name = "idx_pollexecuting_idpoll")]
    [Index("idpollexecutinggroup", Name = "idx_pollexecuting_idpollexecutinggroup")]
    public partial class pollexecuting
    {
        public pollexecuting()
        {
            pollexecutingdiraction = new HashSet<pollexecutingdiraction>();
            pollexecutingitem = new HashSet<pollexecutingitem>();
            pollexecutingsign = new HashSet<pollexecutingsign>();
        }

        [Key]
        public int idpollexecuting { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idcustomer { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpoll { get; set; }
        public int? idpeople { get; set; }
        public int? idpeoplecreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? iddocoper { get; set; }
        public bool? state { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpollexecutinggroup { get; set; }
        public int? iddocstate { get; set; }
        public int? idcustomer2 { get; set; }

        [ForeignKey("idcustomer2")]
        [InverseProperty("pollexecutingidcustomer2Navigation")]
        public virtual customer? idcustomer2Navigation { get; set; }
        [ForeignKey("idcustomer")]
        [InverseProperty("pollexecutingidcustomerNavigation")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("pollexecuting")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("pollexecuting")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("pollexecuting")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("pollexecutingidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeoplecreate")]
        [InverseProperty("pollexecutingidpeoplecreateNavigation")]
        public virtual people? idpeoplecreateNavigation { get; set; }
        [ForeignKey("idpoll")]
        [InverseProperty("pollexecuting")]
        public virtual poll? idpollNavigation { get; set; }
        [ForeignKey("idpollexecutinggroup")]
        [InverseProperty("pollexecuting")]
        public virtual pollexecutinggroup? idpollexecutinggroupNavigation { get; set; }
        [InverseProperty("idpollexecutingNavigation")]
        public virtual ICollection<pollexecutingdiraction> pollexecutingdiraction { get; set; }
        [InverseProperty("idpollexecutingNavigation")]
        public virtual ICollection<pollexecutingitem> pollexecutingitem { get; set; }
        [InverseProperty("idpollexecutingNavigation")]
        public virtual ICollection<pollexecutingsign> pollexecutingsign { get; set; }
    }
}
