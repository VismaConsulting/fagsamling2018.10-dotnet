namespace Visma.Fagsamling.External.Oslobysykkel.Models
{
    public class Stations
    {
        public Station[] stations { get; set; }

        public class Station
        {
            public int id { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public int number_of_locks { get; set; }
            public Center center { get; set; }
            public Bound[] bounds { get; set; }
        }

        public class Center
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Bound
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }
    }
}