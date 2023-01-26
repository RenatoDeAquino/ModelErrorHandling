using FluentValidation.AspNetCore;
using ProjectExceptionModel.API.Endpoints;
using ProjectExceptionModel.API.Models.VMs;
using ProjectExceptionModel.API.Repositories;
using ProjectExceptionModel.API.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<CriarContaVmValidator>();
builder.Services.AddSingleton<ICrirarContaService, CrirarContaService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.CriarContaEndpoint();
app.UseHttpsRedirection();
app.Run();
