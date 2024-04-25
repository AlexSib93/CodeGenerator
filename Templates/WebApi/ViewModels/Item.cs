using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalApi.ViewModels
{
    public class Item<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
