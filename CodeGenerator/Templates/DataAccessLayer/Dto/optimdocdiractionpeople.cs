using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idoptimdoc", Name = "idx_optimdocdiractionpeople_idoptimdoc")]
    [Index("idpeople", Name = "idx_optimdocdiractionpeople_idpeople")]
    public partial class optimdocdiractionpeople
    {
        [Key]
        public int idoptimdocdiractionpeople { get; set; }
        public int? idoptimdocdiraction { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idoptimdoc { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("optimdocdiractionpeople")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
