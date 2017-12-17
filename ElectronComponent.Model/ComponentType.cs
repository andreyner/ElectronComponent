using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent
{
    public class ComponentType
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public IEnumerable<Component> components { get; set; }
        public Guid userid { get; set; }
    }
}
