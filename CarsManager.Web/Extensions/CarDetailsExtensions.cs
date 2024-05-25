using CarsManager.Web.Model;

namespace CarsManager.Web.Extensions
{
    public static class CarDetailsExtensions
    {
        public static bool MatchesFilter(this CarsDetailsViewModel? car, string? filter)
        {
            if (filter is null or { Length: 0 })
            {
                return true;
            }

            if (car is not null)
            {
                return car.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                       || car.Description.Contains(filter, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
