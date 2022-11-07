using PokemonAccedo.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigfureServices(builder.Services);


var app = builder.Build();

startup.ConfigureApp(app, app.Environment);
//app.MapControllers();

app.Run();
