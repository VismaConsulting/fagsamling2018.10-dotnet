using System;

namespace Visma.Fagsamling.External.Oslobysykkel.Models
{
    public class StationAvailability
    {
        public Station[] stations { get; set; }
        public DateTime updated_at { get; set; }
        public float refresh_rate { get; set; }

        public class Station
        {
            public int id { get; set; }
            public Availability availability { get; set; }
        }

        public class Availability
        {
            public int bikes { get; set; }
            public int locks { get; set; }
        }
    }
}