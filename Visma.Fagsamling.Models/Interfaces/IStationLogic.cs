using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Visma.Fagsamling.Domain.Models;

namespace Visma.Fagsamling.Domain.Interfaces
{
    public interface IStationLogic
    {
        Task<List<BikeStation>> GetBikeStation();
    }
}
