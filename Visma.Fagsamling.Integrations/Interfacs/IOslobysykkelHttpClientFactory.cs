using System.Net.Http;

namespace Visma.Fagsamling.External.Interfacs
{
    public interface IOslobysykkelHttpClientFactory
    {
        HttpClient Create();
    }
}