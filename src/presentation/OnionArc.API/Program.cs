using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnionArc.Application;
using OnionArc.Application.Tools;
using OnionArc.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = true;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = JwtTokenDefault.ValidAudience,
            ValidIssuer = JwtTokenDefault.ValidIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key)),
            ValidateLifetime = true
        };
    });

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
