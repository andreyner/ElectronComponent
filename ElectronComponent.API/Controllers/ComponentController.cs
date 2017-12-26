using ElectronComponent.ISql;
using ElectronComponent.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Удаление Компонента
        /// </summary>
        /// <param name="id">id компонента</param>
        [HttpDelete]
        [Route("api/component/{id}")]
        public void Delete(Guid id)
        {

            componentRepository.DellComponent(id);
        }
        /// <summary>
        /// Обновление компонета
        /// </summary>
        /// <param name="">компонент</param>
        /// <returns>компонент</returns>
        [HttpPut]
        [Route("api/component")]
        public Component UpdateComponent([FromBody] Component component)
        {

            return componentRepository.UpdateComponent(component);
        }

        [HttpGet]
        [Route("api/component/{id}")]
        public Component GetComponent(Guid id)
        {
            return componentRepository.GetComponent(id);
        }
    }
}
