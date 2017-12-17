using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.ISql
{
    public interface IUserRepository
    {
        User GetUser(string login,string password);
        User UpdateUser(User user);
        User GreateUser(User user);
        User GetUser(Guid id);
        IEnumerable<Component> GetComponentsofUser(Guid id);
        IEnumerable<ComponentType> GetTypeComponentsofUser(Guid id);

    }
}
