using System;
using System.Net.Http;
using Visma.Fagsamling.External.Interfacs;

namespace Visma.Fagsamling.External.Oslobysykkel
{
    public class OslobysykkelHttpClientFactory : IOslobysykkelHttpClientFactory
    {
        public HttpClient Create()
        {
            var client = new HttpClient(new HttpClientHandler());
            throw new Exception("Legg til nøkkel for Oslo bysykkel");
            client.DefaultRequestHeaders.Add("Client-Identifier", "<Key");
            client.BaseAddress = new Uri("https://oslobysykkel.no/api/v1/");
            return client;
        }
    }
}
