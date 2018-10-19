using System.Threading.Tasks;

namespace Visma.Fagsamling.Domain.Interfaces
{
    public interface ITripLogic
    {
        Task<int> GetTripDuration(string from, string to);
    }
}