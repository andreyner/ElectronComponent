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

        public override bool Equals(object obj)
        {
            if (!(obj is ComponentType)){ return false; }
            if (this.id == ((ComponentType)obj).id)
                return true;
            else { return false; }
        }

        public override int GetHashCode()
        {
            var hashCode = 117852918;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Component>>.Default.GetHashCode(components);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(userid);
            return hashCode;
        }

        public static bool operator ==(ComponentType type1, ComponentType type2)
        {
            return EqualityComparer<ComponentType>.Default.Equals(type1, type2);
        }

        public static bool operator !=(ComponentType type1, ComponentType type2)
        {
            return !(type1 == type2);
        }
    }
}
