using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeoplegroup", Name = "idx_productiontypegrant_idpeoplegroup")]
    [Index("idproductiontype", Name = "idx_productiontypegrant_idproductiontype")]
    public partial class productiontypegrant
    {
        [Key]
        public int idproductiontypegrant { get; set; }
        public int? idpeoplegroup { get; set; }
        public int idproductiontype { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public bool grant { get; set; }

        [ForeignKey("idpeoplegroup")]
        [InverseProperty("productiontypegrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("productiontypegrant")]
        public virtual productiontype idproductiontypeNavigation { get; set; } = null!;
    }
}
