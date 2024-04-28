using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpollexecuting", Name = "idx_pollexecutingitem_idpollexecuting")]
    [Index("idpollrelation", Name = "idx_pollexecutingitem_idpollrelation")]
    public partial class pollexecutingitem
    {
        public pollexecutingitem()
        {
            pollexecutingitemanswer = new HashSet<pollexecutingitemanswer>();
        }

        [Key]
        public int idpollexecutingitem { get; set; }
        public int? idpollexecuting { get; set; }
        public int? idpollrelation { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        public bool? checkvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }

        [ForeignKey("idpollexecuting")]
        [InverseProperty("pollexecutingitem")]
        public virtual pollexecuting? idpollexecutingNavigation { get; set; }
        [ForeignKey("idpollrelation")]
        [InverseProperty("pollexecutingitem")]
        public virtual pollrelation? idpollrelationNavigation { get; set; }
        [InverseProperty("idpollexecutingitemNavigation")]
        public virtual ICollection<pollexecutingitemanswer> pollexecutingitemanswer { get; set; }
    }
}
