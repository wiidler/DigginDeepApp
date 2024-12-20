using DigginDeep.Web.Components;
using DigginDeep.Web.Components.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IStudentService, StudentService>(
client => client.BaseAddress = new Uri("http://localhost:5000"));
builder.Services.AddHttpClient<IOrganizationService, OrganizationService>(
client => client.BaseAddress = new Uri("http://localhost:5000"));
builder.Services.AddHttpClient<IToDoListService, ToDoListService>(
client => client.BaseAddress = new Uri("http://localhost:5000"));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
