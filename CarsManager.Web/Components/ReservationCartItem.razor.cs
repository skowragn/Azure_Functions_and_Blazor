using CarsManager.Web.Model;

namespace CarsManager.Web.Components
{
    public partial class ReservationCartItem
    {
        int _desiredQuantity;
        string Title => $"Update {CarsBookedItem.Car.Name} quantity in cart";

        [Parameter, EditorRequired]
        public CarsBookedItemViewModel CarsBookedItem { get; set; } = null!;

        [Parameter, EditorRequired]
        public EventCallback<CarsDetailsViewModel> OnRemoved { get; set; }

        [Parameter, EditorRequired]
        public EventCallback<(int Quantity, CarsDetailsViewModel Car)> OnUpdated { get; set; }

        protected override void OnParametersSet() => _desiredQuantity = CarsBookedItem.Quantity;

        Task SaveOnUpdateAsync(int value)
        {
            _desiredQuantity = value;
            return TryInvokeDelegate(OnUpdated, (_desiredQuantity, CarsBookedItem.Car));
        }

        Task OnRemoveAsync() => TryInvokeDelegate(OnRemoved, CarsBookedItem.Car);

        Task OnUpdateAsync() => TryInvokeDelegate(OnUpdated, (_desiredQuantity, CarsBookedItem.Car));

        Task TryInvokeDelegate<TArg>(EventCallback<TArg> callback, TArg args) =>
            callback.HasDelegate
                ? callback.InvokeAsync(args)
                : Task.CompletedTask;
    }
}