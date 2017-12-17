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
    public class UserController : ApiController
    {
        private readonly IUserRepository _usersRepository;
        public UserController()
        {
            _usersRepository = new UserRepository();
        }

        /// <summary>
        /// Получить пользователя по логину и паролю
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>пользователь</returns>
        [HttpGet]
        [Route("api/users/{login}/{password}")]
        public User Get(string login, string password)
        {
            return _usersRepository.GetUser(login, password);
        }
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user"> пользователь</param>
        /// <returns><пользователь</returns>
        [HttpPost]
        [Route("api/users")]
        public User CreatUser([FromBody] User user)
        {
            return _usersRepository.GreateUser(user);
        }
        /// <summary>
        /// /Получить типы компонетоы пользователя
        /// </summary>
        /// <param name="userid">id пользователя</param>
        /// <returns> компоненты</returns>
        [HttpGet]
        [Route("api/users/{userid}/typeComponents")]
        public IEnumerable<ComponentType> GetUsersTypeComponents(Guid userid)
        {
            return _usersRepository.GetTypeComponentsofUser(userid);
        }
    }
}
