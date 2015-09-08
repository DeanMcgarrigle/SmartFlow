using SmartFlow.Entity;

namespace SmartFlow.Extensions
{
    public static class FloorDtoExtensions
    {
        public static Floor ToFloorEntity(this string floorName, string apMac)
        {
            return new Floor { Name = floorName, ApMac = apMac };
        }
    }
}