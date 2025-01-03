using LibraryCrud.Components;
using LibraryCrud.Data;
using LibraryCrud.Repositories;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// MSSQLLocalDB config
builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("ConnectionSQLLocalDB"))
        );


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// MY SERVICES
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddRadzenComponents();

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