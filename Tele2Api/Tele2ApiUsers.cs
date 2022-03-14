using Newtonsoft.Json;
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

            var usersWithNotAge = await GetWithNotAge();
            
            var users = usersWithNotAge.Select(async x => await GetUser(x.Id)).Select(x => x.Result).ToArray();

            return users;
        }



        private async Task<User[]> GetWithNotAge()
        {
            var response = await _client.GetAsync(_url);
            var usersData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User[]>(usersData);

            return result;
        }

        private async Task<User> GetUser(string id)
        {
            var respons = await _client.GetAsync(_url + "/" + id);
            var userWithAge = await respons.Content.ReadAsStringAsync();
            var userFull = JsonConvert.DeserializeObject<User>(userWithAge);
            userFull.Id = id;
            return userFull;
        }
    }
}