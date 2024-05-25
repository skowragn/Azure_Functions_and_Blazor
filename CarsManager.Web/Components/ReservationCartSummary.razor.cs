using CarsManager.Web.Model;

namespace CarsManager.Web.Components
{
    public partial class ReservationCartSummary
    {
        string _totalCost => Items?.Sum(x => x.TotalPrice).ToString("C2") ?? ".00";

        [Parameter, EditorRequired]
        public IEnumerable<CarsBookedItemViewModel>? Items { get; set; }
    }
}