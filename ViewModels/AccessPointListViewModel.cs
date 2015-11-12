using System.Collections.Generic;
using SmartFlow.Entity;

namespace SmartFlow.ViewModels
{
    public class AccessPointListViewModel
    {
        public ICollection<AccessPointConfig> AccessPointResults { get; set; }
        public ICollection<string> AccessPoints { get; set; }
        public ICollection<string> Floors { get; set; }
        public string Floor { get; set; }

        public AccessPointListViewModel()
        {
            AccessPointResults = new List<AccessPointConfig>();
            AccessPoints = new List<string>();
            Floors = new List<string>();
        }
    }
}