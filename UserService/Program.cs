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

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var logger = services.GetRequiredService<ILogger<Program>>();
//    var dbContext = services.GetRequiredService<MicroServiceDbContext>();

//    var maxRetries = 10;
//    var delayMilliseconds = 2000;
//    var connected = false;

//    for (int i = 0; i < maxRetries; i++)
//    {
//        try
//        {
//            logger.LogInformation("Försöker ansluta till databasen... Försök {Attempt}", i + 1);
//            await dbContext.Database.OpenConnectionAsync();
//            logger.LogInformation("Anslutning till databasen lyckades.");
//            await dbContext.Database.CloseConnectionAsync();
//            connected = true;
//            break;
//        }
//        catch (Exception ex)
//        {
//            logger.LogWarning(ex, "Misslyckades med att ansluta till databasen. Försöker igen om {Delay} ms...", delayMilliseconds);
//            await Task.Delay(delayMilliseconds);
//        }
//    }

//    if (!connected)
//    {
//        logger.LogError("Kunde inte ansluta till databasen efter {MaxRetries} försök.", maxRetries);
//        throw new Exception("Kunde inte ansluta till databasen.");
//    }

//    // Utför eventuella databasoperationer, t.ex. migreringar
//    dbContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
