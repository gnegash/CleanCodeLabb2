using CleanCodeLabb2;
using CleanCodeLabb2.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<UserRepository>();

var connectionString = builder.Configuration.GetConnectionString("MicroServiceDb");

builder.Services.AddDbContext<MicroServiceDbContext>(
    options => options.UseSqlServer(connectionString)
);

//using SwashBuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MicroServiceDbContext>();
    dbContext.Database.Migrate();

} // databas migration

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
