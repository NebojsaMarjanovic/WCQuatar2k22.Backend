using WCQuatar2k22.BusinessLogic;
using WCQuatar2k22.Domain.Domain;
using WCQuatar2k22.Repository.Implementations;
using WCQuatar2k22.Repository.Interfaces;
using WCQuatar2k22.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDrzavaRepository, DrzavaRepository>();
builder.Services.AddScoped<IStadionRepository, StadionRepository>();
builder.Services.AddScoped<IGrupaRepository, GrupaRepository>();
builder.Services.AddScoped<IDrzavaService, DrzavaService>();
builder.Services.AddScoped<IGrupaService, GrupaService>();
builder.Services.AddScoped<IUtakmicaService, UtakmicaService>();
builder.Services.AddScoped<IUtakmicaRepository, UtakmicaRepository>();
builder.Services.AddScoped<IStadionService, StadionService>();
builder.Services.AddScoped<IStadionRepository, StadionRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<Context>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
