using SmartFlow.DTO.Meraki;

namespace SmartFlow.ViewModels
{
    public class FloorConfigViewModel
    {
        public string Floor { get; set; }
        public FloorConfigDto FloorConfig { get; set; }
        public string ImagePath { get; set; }
    }
}