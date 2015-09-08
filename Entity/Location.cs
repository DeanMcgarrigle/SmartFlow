using System;
using System.Collections.Generic;

namespace SmartFlow.Entity
{
    public class Location
    {
        public Guid RecordId { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public decimal Unc { get; set; }

        public virtual ICollection<FloorLocation> FloorLocations { get; set; }
        public virtual Observation Observation { get; set; }

        public Location()
        {
            FloorLocations = new List<FloorLocation>();
        }
    }
}