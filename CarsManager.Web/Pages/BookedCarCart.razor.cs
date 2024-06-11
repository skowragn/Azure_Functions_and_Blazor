using CarsManager.Web.Services.Interfaces;
using CarsManager.Web.Model;

namespace CarsManager.Web.Pages;

public partial class BookedCarCart
{
    private IEnumerable<CarsBookedItemViewModel>? _carsItems;

    [Inject]
    public ICarReservationsService CarReservationsService { get; set; } = null!;


    [Inject]
    public IBookedCarsItemsService CarBookedItemsService { get; set; } = null!;


    [Inject]
    public ComponentStateChangedObserver Observer { get; set; } = null!;

    protected override Task OnInitializedAsync() => GetBookedCarsItemsAsync();
   
    private Task GetBookedCarsItemsAsync() =>
        InvokeAsync(async () =>
        {
            _carsItems = await CarBookedItemsService.GetAllBookedCarsItems();
            StateHasChanged();
        });

    private async Task OnItemRemovedAsync(CarsDetailsViewModel carDetailsItem)
    {
        if (carDetailsItem != null)
        {
            await CarBookedItemsService.RemoveBookedCarsItem(carDetailsItem.Name, carDetailsItem.UserId);
            await Observer.NotifyStateChangedAsync();

            var itemToRemove = _carsItems?.Where(item => item.Car.Name == carDetailsItem.Name && item.Car.UserId == carDetailsItem.UserId);
            _ = _carsItems.ToList().Remove((CarsBookedItemViewModel)itemToRemove);
        }
    }

    private async Task OnItemUpdatedAsync((int quantity, CarsDetailsViewModel Car) tuple)
    {
        await CarBookedItemsService.AddOrUpdateItem(tuple.quantity, tuple.Car);
        await GetBookedCarsItemsAsync();
    }

    private async Task EmptyCartAsync()
    {
        await CarBookedItemsService.EmptyCarsItem();
        await Observer.NotifyStateChangedAsync();

        _carsItems = new List<CarsBookedItemViewModel>();
    }
}