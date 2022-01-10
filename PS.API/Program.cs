using Microsoft.EntityFrameworkCore;
using PS.API.Extension;
using PS.API.Externsion;
using PS.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDbContextCustom(builder.Configuration);





var app = builder.Build();


app.MigrationDbContext<ApplicationDbContext>();


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
