using CarsManager.Web.Extensions;
using CarsManager.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalStorageServices();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<ComponentStateChangedObserver>();
builder.Services.AddSingleton<ToastService>();

var config = builder.Configuration;
builder.Services.Configure<WebConfiguration>(config.GetSection(nameof(WebConfiguration)));

builder.Services.AddCarReservationsServices(config);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseDefaultFiles(); 

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();
app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();