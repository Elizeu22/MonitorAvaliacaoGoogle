using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Newtonsoft.Json;
using Serilog;

namespace AvaliacaoGoogle
{
    public class ComunicacaoApi
    {
        public  async Task<string?> Comunicacao()
        {
            RegistrarLogs registrarLogs = new RegistrarLogs();
    


            try
            {
                Env.Load(Path.Combine("../../../.env.development"));

                var urlEndereco = DotNetEnv.Env.GetString("URL");
                var apiChave = DotNetEnv.Env.GetString("API_KEY");

                string url = urlEndereco;
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://google.serper.dev/search?q={url}&apiKey={apiChave}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) 
            {
                registrarLogs.RegistrosErrosLogs(ex.Message);
                return null;
            }
        }
    }
}
