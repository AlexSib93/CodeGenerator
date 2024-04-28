using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpollexecutingitem", Name = "idx_pollexecutingitemanswer_idpollexecutingitem")]
    [Index("idpollrelation", Name = "idx_pollexecutingitemanswer_idpollrelation")]
    public partial class pollexecutingitemanswer
    {
        [Key]
        public int idpollexecutingitemanswer { get; set; }
        public int? idpollexecutingitem { get; set; }
        public int? idpollrelation { get; set; }
        public bool? checkedstate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idpollexecutingitem")]
        [InverseProperty("pollexecutingitemanswer")]
        public virtual pollexecutingitem? idpollexecutingitemNavigation { get; set; }
        [ForeignKey("idpollrelation")]
        [InverseProperty("pollexecutingitemanswer")]
        public virtual pollrelation? idpollrelationNavigation { get; set; }
    }
}
