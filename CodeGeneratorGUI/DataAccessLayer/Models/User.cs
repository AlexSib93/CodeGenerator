using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Barcode { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
