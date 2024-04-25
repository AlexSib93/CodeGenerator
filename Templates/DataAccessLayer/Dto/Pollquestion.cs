using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpoll", Name = "idx_pollquestion_idpoll")]
    public partial class pollquestion
    {
        public pollquestion()
        {
            pollrelation = new HashSet<pollrelation>();
        }

        [Key]
        public int idpollquestion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? question { get; set; }
        [Unicode(false)]
        public string? explanation { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? typeanswer { get; set; }
        [Unicode(false)]
        public string? query { get; set; }
        public bool? obligatory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpoll { get; set; }

        [ForeignKey("idpoll")]
        [InverseProperty("pollquestion")]
        public virtual poll? idpollNavigation { get; set; }
        [InverseProperty("idpollquestionNavigation")]
        public virtual ICollection<pollrelation> pollrelation { get; set; }
    }
}
