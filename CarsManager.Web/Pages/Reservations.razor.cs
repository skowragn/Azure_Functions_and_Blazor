using CarsManager.Web.Services.Interfaces;
using CarsManager.Web.Model;

namespace CarsManager.Web.Pages;

public sealed partial class Reservations
{
    private HashSet<CarsDetailsViewModel>? _cars;
    private HashSet<CarsBookedItemViewModel>? _cartItems;

    [Inject]
    public ComponentStateChangedObserver Observer { get; set; } = null!;

    [Inject]
    public ICarReservationsService CarReservationsService { get; set; } = null!;

    [Inject]
    public IBookedCarsItemsService BookedCarsItemsService { get; set; } = null!;
        
    [Inject]
    public ToastService ToastService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _cars = await CarReservationsService.GetAllCarReservations() as HashSet<CarsDetailsViewModel>;
        _cartItems = (HashSet<CarsBookedItemViewModel>?)await BookedCarsItemsService.GetAllBookedCarsItems();
    }


    private async Task OnAddedToCart(string carId)
    {
        var car = _cars?.FirstOrDefault(p => p.UserId == carId);
        if (car is null)
        {
            return;
        }

        if (await CarReservationsService.AddOrUpdateItem(1, car))
        {
            _cars = await CarReservationsService.GetAllCarReservations() as HashSet<CarsDetailsViewModel>;
            _cartItems = (HashSet<CarsBookedItemViewModel>?)await BookedCarsItemsService.GetAllBookedCarsItems();

            await ToastService.ShowToastAsync(
                "Added to reservation",
                $"The '{car.Name}' for {car.Price:C2} was added to your reservation...");
            await Observer.NotifyStateChangedAsync();

            StateHasChanged();
        }
    }

    private bool IsCarAlreadyInCart(CarsDetailsViewModel car) =>
        _cartItems?.Any(c => c.Car.UserId == car.UserId) ?? false;
}
