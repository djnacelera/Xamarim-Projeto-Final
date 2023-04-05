using Newtonsoft.Json;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public class PratoAPI
    {
        HttpClient client;

        public PratoAPI()
        {
            if (client == null)
            {
                HttpClientHandler insecureHandler = GetInsecureHandler();
                client = new HttpClient(insecureHandler);
               // client = new HttpClient();
                client.BaseAddress = new Uri("https://10.0.2.2:7198/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        public async Task<List<Prato>> TodosPratos()
        {
            var response = await client.GetAsync("api/Prato/Listar");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Prato[]>(resultado).ToList();
            }
            else
            {
                return null;
            }
            
        }


       
    }
}
