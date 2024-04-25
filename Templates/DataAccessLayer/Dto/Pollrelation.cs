using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpollanswer", Name = "idx_pollrelation_idpollanswer")]
    [Index("idpollquestion", Name = "idx_pollrelation_idpollquestion")]
    [Index("parentid", Name = "idx_pollrelation_parentid")]
    public partial class pollrelation
    {
        public pollrelation()
        {
            pollexecutingitem = new HashSet<pollexecutingitem>();
            pollexecutingitemanswer = new HashSet<pollexecutingitemanswer>();
        }

        [Key]
        public int idpollrelation { get; set; }
        public int? idpollquestion { get; set; }
        public int? idpollanswer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public int? numpos { get; set; }

        [ForeignKey("idpollanswer")]
        [InverseProperty("pollrelation")]
        public virtual pollanswer? idpollanswerNavigation { get; set; }
        [ForeignKey("idpollquestion")]
        [InverseProperty("pollrelation")]
        public virtual pollquestion? idpollquestionNavigation { get; set; }
        [InverseProperty("idpollrelationNavigation")]
        public virtual ICollection<pollexecutingitem> pollexecutingitem { get; set; }
        [InverseProperty("idpollrelationNavigation")]
        public virtual ICollection<pollexecutingitemanswer> pollexecutingitemanswer { get; set; }
    }
}
