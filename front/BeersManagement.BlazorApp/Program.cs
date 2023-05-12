using BeersManagement.BlazorApp.Application;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplication();

builder.Services.AddHttpClient("BeersManagement.Api",inClient => {
    inClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseAddress") ?? throw new InvalidOperationException("Missing configuration, ApiBaseAddress"));
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (_, _, _, _) => true
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();