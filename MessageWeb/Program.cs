using MessageWeb.Hubs;
using MessageWeb.Models;
using MessageWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.Configure<MessageDatabaseSettings>(
    builder.Configuration.GetSection("MessageDatabase"));
builder.Services.AddSingleton<MessageService>();
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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapHub<MessageHub>("/message");
app.Run();
