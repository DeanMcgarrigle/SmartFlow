using System.Linq;
using SmartFlow.DTO.Meraki;
using SmartFlow.Entity;

namespace SmartFlow.Extensions
{
    public static class LocationDtoExtensions
    {
        public static Location ToLocationEntity(this LocationDto locationDto, DataDto dataDto)
        {
            var location = new Location
            {
                Lat = locationDto.Lat,
                Lng = locationDto.Lng,
                Unc = locationDto.Unc
            };

            var floorLocations = dataDto.ApFloors.Select((value, i) => new { i, value }).Select(item => new FloorLocation
            {
                Name = item.value,
                LocationRecordId = location.RecordId,
                ApMac = dataDto.ApMac,
                X = locationDto.X[item.i],
                Y = locationDto.Y[item.i]
            }).ToList();

            location.FloorLocations = floorLocations;

            return location;
        }
    }
}