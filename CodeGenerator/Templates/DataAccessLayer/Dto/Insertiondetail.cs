using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iderror", Name = "idx_insertiondetail_iderror")]
    [Index("idgood", Name = "idx_insertiondetail_idgood")]
    [Index("idinsertion", Name = "idx_insertiondetail_idinsertion")]
    [Index("idworkoper", Name = "idx_insertiondetail_idworkoper")]
    public partial class insertiondetail
    {
        public insertiondetail()
        {
            insertionparamdetail = new HashSet<insertionparamdetail>();
        }

        [Key]
        public int idinsertiondetail { get; set; }
        public int? idgood { get; set; }
        public int? idinsertion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idworkoper { get; set; }
        public int? iderror { get; set; }

        [ForeignKey("iderror")]
        [InverseProperty("insertiondetail")]
        public virtual error? iderrorNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("insertiondetail")]
        public virtual good? idgoodNavigation { get; set; }
        [ForeignKey("idinsertion")]
        [InverseProperty("insertiondetail")]
        public virtual insertion? idinsertionNavigation { get; set; }
        [ForeignKey("idworkoper")]
        [InverseProperty("insertiondetail")]
        public virtual workoper? idworkoperNavigation { get; set; }
        [InverseProperty("idinsertiondetailNavigation")]
        public virtual ICollection<insertionparamdetail> insertionparamdetail { get; set; }
    }
}
