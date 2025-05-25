using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=times.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();