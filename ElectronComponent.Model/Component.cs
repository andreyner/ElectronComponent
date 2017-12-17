using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent
{
    public class Component
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public  Guid type;
        public User Owner;

    }
}
