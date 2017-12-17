using ElectronComponent.ISql;
using ElectronComponent.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronComponent.API.Controllers
{
    public class ComponentController : ApiController
    {

        public ComponentController()
        {
            componentRepository = new ComponentRepository();
        }
        private  IComponentRepository componentRepository;
        [HttpPost]
        [Route("api/component")]
        public Component CreatComponent([FromBody] Component component)
        {
            return componentRepository.CreateComponent(component);
        }
    }
}
