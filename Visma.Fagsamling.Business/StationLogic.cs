using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Visma.Fagsamling.Domain.Interfaces;
using Visma.Fagsamling.Domain.Models;
using Visma.Fagsamling.External.Interfacs;

namespace Visma.Fagsamling.Business
{
    public class StationLogic : IStationLogic
    {
        private readonly IOslobysykkelClient _client;

        public StationLogic(IOslobysykkelClient client)
        {
            _client = client;
        }

        public async Task<List<BikeStation>> GetBikeStation()
        {
            return await _client.GetBikeStations();
        }
    }
}
