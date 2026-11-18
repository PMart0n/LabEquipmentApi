using LabEquipmentApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// PostgreSQL adatbázis regisztrációja
builder.Services.AddDbContext<LabDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("LabDbConnection")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();