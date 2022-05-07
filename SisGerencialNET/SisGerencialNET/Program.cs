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


using (var contexto = new Context())
{
    var contexto2 = contexto.Bairros
        .Include(a => a.TipoBairro);

    //    .Include(b => b.TiposBairro);

    foreach( var bairro in contexto2 )
    {
        Console.WriteLine(bairro);
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
