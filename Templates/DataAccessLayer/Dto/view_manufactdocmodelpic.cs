using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_manufactdocmodelpic
    {
        public int? idmanufactdoc { get; set; }
        public byte[]? picture { get; set; }
        public int? idmodel { get; set; }
    }
}
