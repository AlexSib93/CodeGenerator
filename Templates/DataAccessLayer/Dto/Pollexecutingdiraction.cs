using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiraction", Name = "idx_pollexecutingdiraction_iddiraction")]
    [Index("idpeopleсreate", Name = "idx_pollexecutingdiraction_idpeopleсreate")]
    [Index("idpollexecuting", Name = "idx_pollexecutingdiraction_idpollexecuting")]
    public partial class pollexecutingdiraction
    {
        [Key]
        public int idpollexecutingdiraction { get; set; }
        public int idpollexecuting { get; set; }
        public int iddiraction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? plandate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? factdate { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeopleсreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("iddiraction")]
        [InverseProperty("pollexecutingdiraction")]
        public virtual diraction iddiractionNavigation { get; set; } = null!;
        [ForeignKey("idpeopleсreate")]
        [InverseProperty("pollexecutingdiraction")]
        public virtual people? idpeopleсreateNavigation { get; set; }
        [ForeignKey("idpollexecuting")]
        [InverseProperty("pollexecutingdiraction")]
        public virtual pollexecuting idpollexecutingNavigation { get; set; } = null!;
    }
}
