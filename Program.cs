using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace poc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = postData();

        }

        public static async Task postData() 
        {
            var url = "https://scx.sondait.com.br/webrun/WSMensagemEnviar.rule?sys=GB1";

            HttpClient client = new HttpClient();

            var body = new Dictionary<string, string> { { "tokenapi", "111B2E63-3DCE-4EC6-8CDB-D6BBB0A6DE13" }, { "idcontato", "leandro.silvak@sonda.com" }, { "idresposta", "consultar_chamado" }, { "ItemId", "7351" } };

            var x = new Post
            {
                tokenapi = "111B2E63-3DCE-4EC6-8CDB-D6BBB0A6DE13",
                idcontato = "leandro.silvak@sonda.com",
                idresposta = "consultar_chamado",
                ItemId = "7351"
            };

            var json = JsonConvert.SerializeObject(x);
            var apiPostData = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponseMessage = client.PostAsync(url, apiPostData).Result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(httpResponseMessage);
        }

    }
}
