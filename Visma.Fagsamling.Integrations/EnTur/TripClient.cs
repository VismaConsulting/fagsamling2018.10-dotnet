using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Visma.Fagsamling.External.EnTur.Models;
using Visma.Fagsamling.External.Interfaces;

namespace Visma.Fagsamling.External.EnTur
{
    public class TripClient : ITripClient
    {
        public async Task<List<Domain.Models.Trip>> GetTrips(string from, string to)
        {
            var request = new GraphQLRequest
            {
                Query = @"query Trip($from:String, $to:String){
                  trip(from:{place: $from} to:{place:$to}) 
  {
    tripPatterns {
      startTime
      duration
      walkDistance

          legs {
          
            mode
            distance
            line {
              id
              publicCode
              authority{
                name
              }
            }
            pointsOnLink {
              points
              length
            }
          }
    }
  }
                }",
                OperationName = "Trip",
                Variables = new
                {
                    from,
                    to
                }
            };

            var client = new GraphQLClient("https://api.entur.org/journeyplanner/2.0/index/graphql");
            client.DefaultRequestHeaders.Add("ET-Client-Name", "Visma-iot");
            var response = await client.PostAsync(request);
            var trips = response.GetDataFieldAs<Trip>("trip");
            return trips.tripPatterns.Select(p => new Domain.Models.Trip
            {
                Duration = p.duration
            }).ToList();
        }
    }
}
