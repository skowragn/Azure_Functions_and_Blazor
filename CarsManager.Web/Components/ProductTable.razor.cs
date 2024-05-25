using CarsManager.Web.Model;
using CarsManager.Web.Extensions;

namespace CarsManager.Web.Components
{
    public partial class ProductTable
    {
        string? _filter;

        CarsDetailsViewModel? _carBeforeEdit;

        [Parameter, EditorRequired]
        public HashSet<CarsDetailsViewModel> Cars { get; set; } = null!;

        [Parameter, EditorRequired]
        public string Title { get; set; } = null!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter, EditorRequired]
        public EventCallback<CarsDetailsViewModel> EditCar { get; set; }

        void OnEdit(object model)
        {
            if (model is CarsDetailsViewModel product &&
                EditCar.HasDelegate)
            {
                _ = EditCar.InvokeAsync(product);
            }
        }

        void BackupItem(object model)
        {
            if (model is CarsDetailsViewModel car)
            {
                _carBeforeEdit = car;
            }
        }

        void RevertEditChanges(object model)
        {
            if (model is CarsDetailsViewModel car &&
                _carBeforeEdit is not null)
            {
                model = new CarsDetailsViewModel();
            }
        }

        bool OnFilter(CarsDetailsViewModel car) => car.MatchesFilter(_filter);
    }
}