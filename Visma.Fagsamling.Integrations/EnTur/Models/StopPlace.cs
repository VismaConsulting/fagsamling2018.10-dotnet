namespace Visma.Fagsamling.External.EnTur.Models
{
    public class StopPlace
    {
        public string id { get; set; }
        public Name name { get; set; }

        public class Name
        {
            public string value { get; set; }
        }
    }
}