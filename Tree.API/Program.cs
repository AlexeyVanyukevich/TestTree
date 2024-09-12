using Tree.API;
using Tree.API.Extensions;
using Tree.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddOptionsSetups();

builder.Services
    .AddPersistence();

builder.Services
    .AddEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiGroup = app.MapGroup(Constants.ApiGroup);

app.MapEndpoints(apiGroup);

app.Run();