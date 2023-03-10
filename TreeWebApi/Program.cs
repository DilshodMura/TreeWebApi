using Database.AppDbContexts;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Mappers;
using Repository.Repositories;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("TreeConnection")));
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<ITreeService,TreeServices>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<ITreeSortRepository, TreeSortRepository>();
builder.Services.AddScoped<ITreeSortService, TreeSortService>();
builder.Services.AddScoped<ITreeTypeRepository, TreeTypeRepository>();
builder.Services.AddScoped<ITreeTypeService, TreeTypeService>();

builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

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
