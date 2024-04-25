﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddelivdoc", Name = "idx_delivdocsign_delivdoc")]
    [Index("idpeople", Name = "idx_delivdocsign_idpeople")]
    [Index("idsign", Name = "idx_delivdocsign_idsign")]
    [Index("idsignvalue", Name = "idx_delivdocsign_idsignvalue")]
    public partial class delivdocsign
    {
        [Key]
        public int iddelivdocsign { get; set; }
        public int? iddelivdoc { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
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

        [ForeignKey("iddelivdoc")]
        [InverseProperty("delivdocsign")]
        public virtual delivdoc? iddelivdocNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("delivdocsign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("delivdocsign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("delivdocsign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
