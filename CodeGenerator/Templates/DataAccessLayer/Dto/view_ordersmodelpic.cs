using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_ordersmodelpic
    {
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        public int? idorder { get; set; }
    }
}
