using System;

namespace SmartFlow.Entity
{
    public class FloorLocation
    {
        public string Name { get; set; }
        public string ApMac { get; set; }
        public Guid LocationRecordId { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public virtual Location Location { get; set; }
        public virtual Floor Floor { get; set; }
    }
}