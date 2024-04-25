using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpollgroup", Name = "idx_poll_idpollgroup")]
    public partial class poll
    {
        public poll()
        {
            pollexecuting = new HashSet<pollexecuting>();
            pollquestion = new HashSet<pollquestion>();
        }

        [Key]
        public int idpoll { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpollgroup { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? group { get; set; }

        [ForeignKey("idpollgroup")]
        [InverseProperty("poll")]
        public virtual pollgroup? idpollgroupNavigation { get; set; }
        [InverseProperty("idpollNavigation")]
        public virtual ICollection<pollexecuting> pollexecuting { get; set; }
        [InverseProperty("idpollNavigation")]
        public virtual ICollection<pollquestion> pollquestion { get; set; }
    }
}
