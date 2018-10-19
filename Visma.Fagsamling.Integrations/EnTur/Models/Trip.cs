using System;

namespace Visma.Fagsamling.External.EnTur.Models
{
    public class Trip
    {
        public Trippattern[] tripPatterns { get; set; }

        public class Trippattern
        {
            public DateTime startTime { get; set; }
            public int duration { get; set; }
            public float walkDistance { get; set; }
            public Leg[] legs { get; set; }
        }

        public class Leg
        {
            public string mode { get; set; }
            public float distance { get; set; }
            public Line line { get; set; }
            public Pointsonlink pointsOnLink { get; set; }
        }

        public class Line
        {
            public string id { get; set; }
            public string publicCode { get; set; }
            public Authority authority { get; set; }
        }

        public class Authority
        {
            public string name { get; set; }
        }

        public class Pointsonlink
        {
            public string points { get; set; }
            public int length { get; set; }
        }
    }
}