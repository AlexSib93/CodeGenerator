using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodanalogdetail__639A6E01", IsUnique = true)]
    [Index("idgood", Name = "idx_goodanalogdetail_idgood")]
    [Index("idgoodanalog", Name = "idx_goodanalogdetail_idgoodanalog")]
    public partial class goodanalogdetail
    {
        [Key]
        public int idgoodanalogdetail { get; set; }
        public int? idgoodanalog { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idgood")]
        [InverseProperty("goodanalogdetail")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idgoodanalog")]
        [InverseProperty("goodanalogdetail")]
        public virtual goodanalog? idgoodanalogNavigation { get; set; }
    }
}
