using System.Net.Http;

namespace Visma.Fagsamling.External.Interfaces
{
    public interface IOslobysykkelHttpClientFactory
    {
        HttpClient Create();
    }
}