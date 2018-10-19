using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Visma.Fagsamling.Domain.Models;
using Visma.Fagsamling.External.EnTur.Models;
using Visma.Fagsamling.External.Interfaces;

namespace Visma.Fagsamling.External.EnTur
{
    public class PlaceClient : ITopographicplaceClient
    {
        public async Task<List<Place>> GetLocations(string location)
        {
            var request = new GraphQLRequest
            {
                Query = @"query Place($location:String){
                  stopPlace(query: $location) {
                    id
                    name {
                      value
                    }
                  }
                }",
                OperationName = "Place",
                Variables = new
                {
                    location
                }
            };

            var client = new GraphQLClient("https://api.entur.org/stop_places/1.0/graphql");
            client.DefaultRequestHeaders.Add("ET-Client-Name", "Visma-iot");
            var response = await client.PostAsync(request);
            var places = response.GetDataFieldAs<List<StopPlace>>("stopPlace");
            return places.Select(place => new Place
            {
                Id = place.id,
                Name = place.name.value
            }).ToList();
        }
    }
}