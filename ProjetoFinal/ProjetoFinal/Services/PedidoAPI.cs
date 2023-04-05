
using Newtonsoft.Json;
using ProjetoFinal.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace AceleraPleno.API.Repository
{
    public class PedidoAPI
    {
        HttpClient client;

        public PedidoAPI()
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

    }
}
