using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using ArticlesAppXamarin.Models; 

namespace ArticlesAppXamarin.Data
{
    public class RestService: IRestService
    {
        HttpClient _client;

        public List<ArticleModel> Articles { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<ArticleModel>> RefreshDataAsync()
        {
            Articles = new List<ArticleModel>();

            var uri = new Uri(string.Format(Constants.ArticleItemsUrl, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Articles = JsonConvert.DeserializeObject<List<ArticleModel>>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
            return Articles;
        }

        public async Task<bool> AuthorizeAsync(LoginModel loginModel)
        {
            var uri = new Uri(string.Format(Constants.LoginUrl,string.Empty));
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await _client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Success");
                    return true;
                }
                else
                {
                    Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                    return false;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
