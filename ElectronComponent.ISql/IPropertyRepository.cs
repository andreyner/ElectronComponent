using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.ISql
{
    public   interface IPropertyRepository
    {
        Component GreateProperty(Property property);
        Component UpdateProperty(Property property);
        void DellProperty(Guid  id);
    }
}
