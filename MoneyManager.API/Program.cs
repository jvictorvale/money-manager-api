using MoneyManager.API.Configurations;
using MoneyManager.Application;
using MoneyManager.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration, builder);
builder.Services.AddInfraData(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();