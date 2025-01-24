var builder = WebApplication.CreateBuilder(args);

// Добавьте поддержку контроллеров и представлений
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();