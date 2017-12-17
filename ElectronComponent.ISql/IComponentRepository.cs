using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.ISql
{
    public interface IComponentRepository
    {
        Component CreateComponent(Component component);
        Component GetComponent(Guid  id);
        Component UpdateComponent(Component component);
        void DellComponent(Guid id);
    }
}
