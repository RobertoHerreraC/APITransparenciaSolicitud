using DAL.Configuracion;
using DAL.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<Conexion>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<ISolicitudRepositorio, SolicitudRepositorio>(); 
builder.Services.AddScoped<IResponsableRepositorio, ResponsableRepositorio>();
builder.Services.AddScoped<IFormaEntregaRepositorio, FormaEntregaRepositorio>();
builder.Services.AddScoped<IPlazoRepositorio, PlazoRepositorio>();
builder.Services.AddScoped<IPersonaAPIRepositorio, PersonaAPIRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("newPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
                 .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("newPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
