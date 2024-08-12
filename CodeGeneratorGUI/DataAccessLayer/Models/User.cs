using System;

namespace DataAccessLayer.Dto
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
