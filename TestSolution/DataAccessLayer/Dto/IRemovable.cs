using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IRemovable
    {
        DateTime? deleted { get; set; }
    }
}
