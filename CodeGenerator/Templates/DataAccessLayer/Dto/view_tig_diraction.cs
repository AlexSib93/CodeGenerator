using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_tig_diraction
    {
        public int? idorder { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanZamer { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactZamer { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? CommentZamer { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanPrin { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactPrin { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentPrin { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanProizv { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactProizv { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentProizv { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanProizvMosk { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactProizvMosk { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentProizvMosk { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanMont { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactMont { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentMont { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanOtgr { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactOtgr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentOtgr { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? PlanEndMont { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? FactEndMont { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? commentEndMont { get; set; }
    }
}
