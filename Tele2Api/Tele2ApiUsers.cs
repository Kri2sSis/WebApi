using Newtonsoft.Json;
using System.Net;
using WebApi.Core.Repositories;
using WebApi.Core.Tele2Api;

namespace Tele2Api
{
    public class Tele2ApiUsers : ITele2ApiUsers
    {
        private string _urlGetUsers = "http://testlodtask20172.azurewebsites.net/task";

        public User[] Get()
        {
            List<User> users = new List<User>();
            dynamic jsonresult = GetJson(_urlGetUsers);

            foreach (var item in jsonresult)
            {
                users.Add(new User
                {
                    UserId = item.id,
                    UserFullName = item.name,
                    Sex = item.sex,
                    Age = GetAge(item.id.ToString())
                });
            }


            return users.ToArray();
        }

        public int GetAge(string id)
        {
            var result = GetJson(_urlGetUsers + '/' + id);

            return result.age;
        }

        private dynamic GetJson(string url)
        {
            HttpWebRequest requet = (HttpWebRequest)WebRequest.Create(url);
            var response = requet.GetResponse();
            var resultResponse = response.GetResponseStream();
            var result = new StreamReader(resultResponse).ReadToEnd();
            response.Close();
            dynamic jsonresult = JsonConvert.DeserializeObject(result);
            return jsonresult;
        }
    }
}