using Basket.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cofiguration = builder.Configuration;
var connectionString = cofiguration.GetValue<string>("CacheSettings:ConnectionString");
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = connectionString;
});
builder.Services.AddControllers();
builder.Services.AddScoped<IBaskerRepository, BaskerRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
