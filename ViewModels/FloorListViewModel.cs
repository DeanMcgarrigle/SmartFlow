using System.Collections.Generic;
using SmartFlow.Entity;

namespace SmartFlow.ViewModels
{
    public class FloorListViewModel
    {
        public ICollection<string> Floors { get; set; }
        public ICollection<FloorConfig> FloorResults { get; set; }

        public FloorListViewModel()
        {
            Floors = new List<string>();
            FloorResults = new List<FloorConfig>();
        }
    }
}