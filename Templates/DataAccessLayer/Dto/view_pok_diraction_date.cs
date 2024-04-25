using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pok_diraction_date
    {
        public int? idorder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanZamer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactZamer { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentZamer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanPrin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactPrin { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentPrin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanProizv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactProizv { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentProizv { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanMont { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactMont { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentMont { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanOtgr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactOtgr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentOtgr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PlanEndMont { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FactEndMont { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentEndMont { get; set; }
    }
}
