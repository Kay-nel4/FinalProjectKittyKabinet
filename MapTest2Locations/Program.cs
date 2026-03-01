using System.Data;
using MapTest2Locations.Data;
using MapTest2Locations.MessageBoardData;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection connection = new MySqlConnection(builder.Configuration.GetConnectionString("kittykabinet"));
    connection.Open();
    return connection;
});

builder.Services.AddTransient<IKabinetRepository, KabinetRepository>();
builder.Services.AddTransient<IMessageBoardRepository, MessageBoardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();