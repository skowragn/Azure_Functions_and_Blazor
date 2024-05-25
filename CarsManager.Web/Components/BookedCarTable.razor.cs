using CarsManager.Web.Extensions;
using CarsManager.Web.Model;

namespace CarsManager.Web.Components
{
    public partial class BookedCarTable
    {
        string? _filter;

        [Parameter, EditorRequired]
        public HashSet<CarsDetailsViewModel>? Cars { get; set; } = null!;

        [Parameter, EditorRequired]
        public string Title { get; set; } = null!;

        [Parameter, EditorRequired]
        public EventCallback<string> OnAddedToCart { get; set; }

        [Parameter, EditorRequired]
        public Func<CarsDetailsViewModel, bool> IsInCart { get; set; } = null!;

        Task AddToCartAsync(string carId) =>
            OnAddedToCart.HasDelegate
                ? OnAddedToCart.InvokeAsync(carId)
                : Task.CompletedTask;

        bool OnFilter(CarsDetailsViewModel car) => car.MatchesFilter(_filter);
    }
}