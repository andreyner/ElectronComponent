using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ElectronComponent.Wpf
{
    public class ServiceClient
    {
        private readonly HttpClient _client;
        public ServiceClient(string connectionString)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(connectionString);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public User CreateUser(User user)
        {
            var userres = _client.PostAsJsonAsync("users", user).Result;
            switch (userres.StatusCode)
            {
                case HttpStatusCode.OK: return userres.Content.ReadAsAsync<User>().Result;
                case HttpStatusCode.Forbidden: throw new Exception("Логин уже занят!");
                case HttpStatusCode.BadRequest: throw new Exception(userres.RequestMessage.ToString());
                default: throw new Exception("Не удалось создать пользователя!");
            }
        }
        public User FindUser(string Login, string Password)
        {

            var response = _client.GetAsync($"users/{Login}/{Password}").Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: return response.Content.ReadAsAsync<User>().Result;
                default: throw new Exception("Ошибка при входе в приложение!");
            }


        }
        public ComponentType CreateComponentType(ComponentType componenttype)
        {
            var resnote = _client.PostAsJsonAsync("components", componenttype).Result;
            switch (resnote.StatusCode)
            {
                case HttpStatusCode.OK: return resnote.Content.ReadAsAsync<ComponentType>().Result;
                default: throw new Exception("Не удалось создать тип компанента!");
            }


        }
        public IEnumerable<Component> GetComponentsofUser(Guid userid)
        {
            var response = _client.GetAsync($"users/{userid}/typeComponents").Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: return response.Content.ReadAsAsync<IEnumerable<Component>>().Result;
                default: throw new Exception("Не удалось получить типы компонентов!");
            }
        }
        public IEnumerable<ComponentType> GetTypeComponentsofUser(Guid userid)
        {
            var response = _client.GetAsync($"users/{userid}/typeComponents").Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: return response.Content.ReadAsAsync<IEnumerable<ComponentType>>().Result;
                default: throw new Exception("Не удалось получить типы компонентов!");
            }
        }

        public Component CreateComponent(Component component)
        {
            var resnote = _client.PostAsJsonAsync("component", component).Result;
            switch (resnote.StatusCode)
            {
                case HttpStatusCode.OK: return resnote.Content.ReadAsAsync<Component>().Result;
                default: throw new Exception("Не удалось создать компонент!");
            }


        }



    }
}
