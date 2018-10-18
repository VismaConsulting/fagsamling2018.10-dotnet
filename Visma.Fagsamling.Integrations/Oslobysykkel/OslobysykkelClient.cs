using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Visma.Fagsamling.Domain.Models;
using Visma.Fagsamling.External.Interfacs;
using Visma.Fagsamling.External.Oslobysykkel.Models;

namespace Visma.Fagsamling.External.Oslobysykkel
{
    public class OslobysykkelClient : IOslobysykkelClient
    {
        private readonly HttpClient _httpClient;

        public OslobysykkelClient(IOslobysykkelHttpClientFactory httpClient)
        {
            _httpClient = httpClient.Create();
        }

        public async Task<List<BikeStation>> GetBikeStations()
        {
            var stations = await GetStations();
            var stationAvailability = await GetStationAvailability();
            var bikeStation = new List<BikeStation>();
            foreach (var station in stations.stations)
            {
                var availability = stationAvailability.stations.Single(s => s.id == station.id).availability;
                bikeStation.Add(new BikeStation
                {
                    Id = station.id,
                    TotalNumberOfLocks = station.number_of_locks,
                    Bikes = availability.bikes,
                    Locks = availability.locks,
                    Title = station.title
                });
            }

            return bikeStation;
        }

        private async Task<StationAvailability> GetStationAvailability()
        {
            var availability = await _httpClient.GetAsync("stations/availability");
            var result = await availability.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StationAvailability>(result);
        }

        private async Task<Stations> GetStations()
        {
            var station = await _httpClient.GetAsync("stations");
            var result = await station.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Stations>(result);
        }


    }
}