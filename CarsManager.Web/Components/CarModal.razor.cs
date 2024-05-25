using CarsManager.Web.Model;

namespace CarsManager.Web.Components
{
    public partial class CarModal
    {
        bool _isSaving;
        MudForm? _form;

        public CarsDetailsViewModel Cars { get; set; } = new();

        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = null!;

        [Parameter, EditorRequired]
        public EventCallback<CarsDetailsViewModel> CarUpdated { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        public void Open(string title, Func<CarsDetailsViewModel, Task> onCarUpdated) =>
            DialogService.Show<CarModal>(
                title, new DialogParameters()
                {
                {
                    nameof(CarUpdated),
                    new EventCallbackFactory().Create(
                        this, new Func<CarsDetailsViewModel, Task>(onCarUpdated))
                }
                });

        public void Close() => MudDialog?.Cancel();

        private Task Save()
        {
            if (_form is not null)
            {
                _form.Validate();
                if (_form.IsValid)
                {
                    return OnValidSubmitAsync();
                }
            }

            return Task.CompletedTask;
        }

        private async Task OnValidSubmitAsync()
        {
            if (Cars is not null && CarUpdated.HasDelegate)
            {
                try
                {
                    _isSaving = true;
                    await CarUpdated.InvokeAsync(Cars);
                }
                finally
                {
                    _isSaving = false;
                    Close();
                }
            }
        }
    }
}