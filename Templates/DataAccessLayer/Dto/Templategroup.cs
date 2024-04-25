using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("parentid", Name = "idx_templategroup_parentid")]
    public partial class templategroup
    {
        public templategroup()
        {
            template = new HashSet<template>();
        }

        [Key]
        public int idtemplategroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? parentid { get; set; }
        public int? typ { get; set; }

        [InverseProperty("idtemplategroupNavigation")]
        public virtual ICollection<template> template { get; set; }
    }
}
