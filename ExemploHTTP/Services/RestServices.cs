using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHTTP.Models;
using System.Text.Json;

namespace ExemploHTTP.Services
{
    internal class RestServices
    {
        private HttpClient client;
        private Post post;
        private List<Post> posts;
        private JsonSerializerOptions _serializerOptions;

        RestServices() 
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
        }

        public async Task <List<Post>> GetPostsAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                posts = JsonSerializer.Deserialize<List<Post>>(content, _serializerOptions);

            }
        }
    }
}
