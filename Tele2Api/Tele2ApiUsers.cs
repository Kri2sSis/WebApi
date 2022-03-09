using Newtonsoft.Json;
using System.Net;
using WebApi.Core.Repositories;
using WebApi.Core.Tele2Api;

namespace Tele2Api
{
    public class Tele2ApiUsers : ITele2ApiUsers
    {
        private string _urlGetUsers = "http://testlodtask20172.azurewebsites.net/task";

        private HttpClient _client;
        private Uri _url = new Uri("http://testlodtask20172.azurewebsites.net/task");

        public Tele2ApiUsers()
        {
            _client = new HttpClient();
        }

        public async Task<User[]> Get()
        {
            List<User> users = new List<User>();

            var usersWithNotAge = await GetWithNotAge();
            foreach (var user in usersWithNotAge)
            {
                var respons = await _client.GetAsync(_url + "/" + user.Id);
                var userWithAge = await respons.Content.ReadAsStringAsync();
                var userFull = JsonConvert.DeserializeObject<User>(userWithAge);
                userFull.Id = user.Id;
                users.Add(userFull);
            }

            return users.ToArray();
        }



        private async Task<User[]> GetWithNotAge()
        {
            var response = await _client.GetAsync(_url);
            var usersData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User[]>(usersData);

            return result;
        }
    }
}