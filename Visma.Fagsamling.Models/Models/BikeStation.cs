using System;
using System.Collections.Generic;
using System.Text;

namespace Visma.Fagsamling.Domain.Models
{
    public class BikeStation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Bikes { get; set; }
        public int Locks { get; set; }
        public int TotalNumberOfLocks { get; set; }
    }
}
