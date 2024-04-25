﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_productiondocsign_idpeople")]
    [Index("idproductiondoc", Name = "idx_productiondocsign_idproductiondoc")]
    [Index("idsign", Name = "idx_productiondocsign_idsign")]
    public partial class productiondocsign
    {
        [Key]
        public int idproductiondocsign { get; set; }
        public int? idproductiondoc { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("productiondocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idproductiondoc")]
        [InverseProperty("productiondocsign")]
        public virtual productiondoc? idproductiondocNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("productiondocsign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}