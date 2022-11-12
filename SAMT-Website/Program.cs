using Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var serverVersion = new MariaDbServerVersion(new Version(10, 6, 7));
builder.Services.AddDbContextFactory<samt_websiteContext>(options =>
    options.UseMySql($"server=landofrails.net;port=3306;user=samt;password={File.ReadAllText("sensitive-data")};database=samt_website", serverVersion));

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

app.UseCors("NewPolicy");

app.UseRequestLocalization("de-DE");

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
