using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddepartment", Name = "idx_messages_iddepartment")]
    [Index("idmessagetype", Name = "idx_messages_idmessagetype")]
    [Index("idpeople", Name = "idx_messages_idpeople")]
    [Index("idpeople2", Name = "idx_messages_idpeople2")]
    public partial class messages
    {
        [Key]
        public int idmessage { get; set; }
        public int? idmessagetype { get; set; }
        [Column(TypeName = "text")]
        public string? messagetext { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        public short? isread { get; set; }
        public byte[]? addfile { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addfilename { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtaction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtread { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? answer { get; set; }
        public int? iddoc { get; set; }
        public int? iddocappearance { get; set; }
        public bool? check { get; set; }
        public int? iddepartment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcheck { get; set; }
        [Unicode(false)]
        public string? bodytext { get; set; }

        [ForeignKey("iddepartment")]
        [InverseProperty("messages")]
        public virtual department? iddepartmentNavigation { get; set; }
        [ForeignKey("idmessagetype")]
        [InverseProperty("messages")]
        public virtual messagetype? idmessagetypeNavigation { get; set; }
        [ForeignKey("idpeople2")]
        [InverseProperty("messagesidpeople2Navigation")]
        public virtual people? idpeople2Navigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("messagesidpeopleNavigation")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
