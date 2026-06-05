using PruebaTecnica.Entities.Configuration;
using PruebaTecnica.DataLogic.Clases;
using PruebaTecnica.DataLogic.Interfaces;
using _PruebaTecnica.businessLogic.Clases;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ExternalApiSettings>(
    builder.Configuration.GetSection("ExternalApis"));

builder.Services.AddHttpClient("RickAndMortyClient", (serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<ExternalApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.RickAndMortyBaseUrl);
});

builder.Services.AddScoped<IEpisodiosDAL, EpisodiosDAL>();
builder.Services.AddScoped<EpisodiosBLL>();
builder.Services.AddScoped<IPersonajesDAL, PersonajesDAL>();
builder.Services.AddScoped<PersonajesBLL>();

// Registro de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<PruebaTecnicaCarsalesBFF.Middlewares.ErrorHandlingMiddleware>();

app.Run();