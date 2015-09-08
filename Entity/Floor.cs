using System.Collections.Generic;

namespace SmartFlow.Entity
{
    public class Floor
    {
        public string Name { get; set; }
        public string ApMac { get; set; }

        public virtual ICollection<FloorLocation> FloorLocations { get; set; }

        public Floor()
        {
            FloorLocations = new List<FloorLocation>();
        }
    }
}