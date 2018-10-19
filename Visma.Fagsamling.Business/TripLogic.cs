using System;
using System.Linq;
using System.Threading.Tasks;
using Visma.Fagsamling.Domain.Interfaces;
using Visma.Fagsamling.External.Interfaces;

namespace Visma.Fagsamling.Business
{
    public class TripLogic : ITripLogic
    {
        private readonly ITopographicplaceClient _topographicplaceClient;
        private readonly ITripClient _tripClient;

        public TripLogic(ITopographicplaceClient topographicplaceClient, ITripClient tripClient)
        {
            _topographicplaceClient = topographicplaceClient;
            _tripClient = tripClient;
        }

        public async Task<int> GetTripDuration(string from, string to)
        {
            var fromPlace = (await _topographicplaceClient.GetLocations(from))?.FirstOrDefault();
            var toPlace = (await _topographicplaceClient.GetLocations(to))?.FirstOrDefault();
            var duration = await _tripClient.GetTrips(fromPlace?.Id, toPlace?.Id);
            return duration.First().Duration;
        }
    }
}