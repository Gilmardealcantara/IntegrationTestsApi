using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api.Services
{
    public class GitService : IGitService
    {
        public async Task<string[]> GetGitRepos(string userName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", "1"));
                var url = $"https://api.github.com/users/{userName}/repos";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<JObject[]>();
                    return data.Select(x => x["name"].ToString()).ToArray();
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
                    Console.WriteLine(url);
                }
            }
            return new string[] { };
        }
    }
}