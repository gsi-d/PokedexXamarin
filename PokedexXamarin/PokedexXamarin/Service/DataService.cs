using Newtonsoft.Json;
using PokedexXamarin.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace XF_ConsumindoWebAPI.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Skills>> GetProdutosAsync()
        {
            try
            {
                string url = "https://pokeapi.co";
                var response = await client.GetStringAsync(url);
                var pokemon = JsonConvert.DeserializeObject<List<Skills>>(response);
                return pokemon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddProdutoAsync(Skills pokemon)
        {
            try
            {
                string url = "https://pokeapi.co";
                var uri = new Uri(string.Format(url, pokemon.Id));
                var data = JsonConvert.SerializeObject(pokemon);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public async Task UpdateProdutoAsync(Produto produto)
        {
            string url = "https://pokeapi.co";
            var uri = new Uri(string.Format(url, produto.Id));
            var data = JsonConvert.SerializeObject(produto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar produto");
            }
        }
        public async Task DeletaProdutoAsync(Produto produto)
        {
            string url = "https://pokeapi.co";
            var uri = new Uri(string.Format(url, produto.Id));
            await client.DeleteAsync(uri);
        }*/
    }
}