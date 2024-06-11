using CarsManager.Web.Services.Interfaces;
using CarsManager.Web.Model;

namespace CarsManager.Web.Pages;

public partial class Cars
{
    private HashSet<CarsDetailsViewModel>? _cars;
    private CarModal? _modal;

    [Parameter]
    public string? Id { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public ICarReservationsService CarReservationsService { get; set; } = null!;

    [Inject]
    public IBookedCarsItemsService BookedCarsItemsService { get; set; } = null!;

    protected override async Task OnInitializedAsync() => GetAllCarReservationsAsync();

    private Task GetAllCarReservationsAsync() =>
            InvokeAsync(async () =>
            {
                _cars = (HashSet<CarsDetailsViewModel>?)await CarReservationsService.GetAllCarReservations();
                StateHasChanged();
            });



    private void CreateNewCar()
    {
        if (_modal is not null)
        {
            var car = new CarsDetailsViewModel();
            //var carMock = new CarDetailsDataGenerator().GetCar(CarTypes.Jaguar);
            //_modal.Cars = carMock;
            //_modal.Open("Create Car", OnCarUpdated);
        }
    }

    private async Task OnCarUpdated(CarsDetailsViewModel car)
    {
        await CarReservationsService.CreateOrUpdateCar(car);

        _cars = (HashSet<CarsDetailsViewModel>?)await CarReservationsService.GetAllCarReservations();

        _modal?.Close();

        StateHasChanged();
    }

    private Task OnEditCar(CarsDetailsViewModel car) =>
        OnCarUpdated(car);
}