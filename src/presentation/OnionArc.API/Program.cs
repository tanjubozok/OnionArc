using OnionArc.Application;
using OnionArc.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region ServiceRegistrations

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
