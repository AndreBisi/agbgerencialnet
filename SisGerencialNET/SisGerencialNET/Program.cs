using Microsoft.EntityFrameworkCore;
using SisGerencialNET.Controllers.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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


using (var contexto = new BairroContext())
{
    var contexto2 = contexto.TiposBairro
        .Include(b => b.BairroList);

    foreach( var bairro in contexto.Bairros )
    {
        Console.WriteLine(bairro);
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
