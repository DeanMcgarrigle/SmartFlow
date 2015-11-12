using SmartFlow.DTO.Meraki;

namespace SmartFlow.ViewModels
{
    public class AccessPointConfigViewModel
    {
        public string Floor { get; set; }
        public string AccessPoint { get; set; }
        public AccessPointConfigDto AccessPointConfig { get; set; }
    }
}