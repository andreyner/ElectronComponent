using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.ISql
{
    public interface IComponentTypeRepository
    {
        ComponentType GreateComponentType(ComponentType componentType);
        ComponentType UpdateComponentType(ComponentType componentType);
        IEnumerable<Component> GetComponentsofType(Guid typeid);
        void  DellComponentType(Guid componentTypeid);
    }
}
