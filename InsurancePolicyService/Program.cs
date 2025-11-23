using InsurancePolicyService.Data;
using InsurancePolicyService.Models;
using InsurancePolicyService.Repositories;
using InsurancePolicyService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InsurancePolicyDbContext>(opt =>
    opt.UseInMemoryDatabase("PolicyNotesDb"));

builder.Services.AddScoped<IPolicyNotesRepository, PolicyNotesRepository>();
builder.Services.AddScoped<IPolicyNotesService, PolicyNotesService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/notes", (PolicyNote req, IPolicyNotesService service) =>
{
    var created = service.AddNote(req.PolicyNumber, req.Note);
    return Results.Created($"/notes/{created.Id}", created);
});

app.MapGet("/notes", (IPolicyNotesService service) =>
{
    return Results.Ok(service.GetNotes());
});

app.MapGet("/notes/{id}", (int id, IPolicyNotesService service) =>
{
    var note = service.GetById(id);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

app.Run();

public partial class Program { }
