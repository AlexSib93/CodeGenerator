using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class ganttchart
    {
        public ganttchart()
        {
            power = new HashSet<power>();
        }

        [Key]
        public int idganttchart { get; set; }
        [Unicode(false)]
        public string? model { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }

        [InverseProperty("idganttchartNavigation")]
        public virtual ICollection<power> power { get; set; }
    }
}
