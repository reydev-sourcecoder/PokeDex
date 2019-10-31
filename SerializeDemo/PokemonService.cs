using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SerializeDemo
{
    public class PokemonService
    {
        private static string _baseApi = "https://pokeapi.co/api/v2/pokemon/{0}";
        public static async Task<string> GetPokeMon(string name)
        {
            string response = null;

            using (var client = new HttpClient())
            {
                var uri = new Uri(string.Format(_baseApi, name));
                response = await client.GetStringAsync(uri);
                if (string.IsNullOrEmpty(response)) return string.Empty;
                return response;
            }
        }
    }
}
