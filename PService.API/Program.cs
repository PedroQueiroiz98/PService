using PService.API;

var builder = WebApplication.CreateBuilder(args);

var statup = new Startup(builder.Configuration);

statup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
statup.Configure(app,app.Environment);

app.Run();
