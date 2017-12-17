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
    public class ComponentTypeController : ApiController
    {
        private readonly IComponentTypeRepository componentTypeRepository;
        public ComponentTypeController()
        {
            componentTypeRepository = new ComponentTypeRepository();
        }
        [HttpPost]
        [Route("api/components")]
        public ComponentType CreatComponents([FromBody] ComponentType component)
        {
            return componentTypeRepository.GreateComponentType(component) ;
        }
    }
}
