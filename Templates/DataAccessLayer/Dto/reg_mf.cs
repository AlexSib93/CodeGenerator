﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class reg_mf
    {
        public int idmanufactdoc { get; set; }
        public int idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int idstoredepart { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal pr { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal ra { get; set; }

        [ForeignKey("idcolor1")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idgood")]
        public virtual good idgoodNavigation { get; set; } = null!;
        [ForeignKey("idmanufactdoc")]
        public virtual manufactdoc idmanufactdocNavigation { get; set; } = null!;
        [ForeignKey("idstoredepart")]
        public virtual storedepart idstoredepartNavigation { get; set; } = null!;
    }
}
