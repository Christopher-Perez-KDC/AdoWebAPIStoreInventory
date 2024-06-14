using AdoWebApiStoreInventory.Repositories.Repositories;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;
using AdoWebAPIStoreInventory;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<FoodMarketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure HTTPS redirection
app.UseHttpsRedirection();

// Allow CORS
app.UseCors(x => x.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin());

app.UseAuthorization();
app.MapControllers();
app.Run();
