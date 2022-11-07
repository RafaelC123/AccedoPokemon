using Newtonsoft.Json;
using PokemonAccedo.Api.Data;
using PokemonAccedo.Api.RepositoriesHttp.Repositories.Interfaces;

namespace PokemonAccedo.Api.RepositoriesHttp.Repositories
{
    public class RepositoryGeneric<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RepositoryGeneric(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetFirst(string Url)
        {
            var Client = httpClientFactory.CreateClient("VoidClient");
            HttpResponseMessage Response = await Client.GetAsync(Url);
            if (Response.IsSuccessStatusCode)
            {
                var Content = await Response.Content.ReadAsStringAsync();
                T Data = JsonConvert.DeserializeObject<T>(Content);
                return Data;
            }
            return null;
        }



        public async Task<T> GetList()
        {
            var Client = httpClientFactory.CreateClient("PokemonApi");
            HttpResponseMessage Response = await Client.GetAsync(UrlClient.GetAllPokemons);
            if (Response.IsSuccessStatusCode)
            {
                var Content = await Response.Content.ReadAsStringAsync();
                T Data = JsonConvert.DeserializeObject<T>(Content);
                return Data;
            }
            return null;
        }
    }
}
