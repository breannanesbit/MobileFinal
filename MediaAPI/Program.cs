using Azure.Storage.Blobs;
using MediaAPI;
using MediaAPI.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var blobstring = builder.Configuration["blobString"];
var database = builder.Configuration["database"];

builder.Services.AddDbContext<MultiMediaAppContext>(options => {
    options.UseNpgsql(database);
    });
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<MultiMediaAppContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddSingleton(x => new BlobServiceClient(blobstring));
//BlobServiceClient blobServiceClient = new(blobstring);
var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();