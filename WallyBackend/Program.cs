using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using WallyBackend.core.Interfaces;
using WallyBackend.core.Services;
using WallyBackend.Infrastructure.Data;
using WallyBackend.Infrastructure.Repositories;
using WallyBackend.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);
//conection to the database
var _configuration = builder.Configuration;
var connectionString = _configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<WallyprojectContext>( options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString) );
});


//conexiones a los servicios y repositorios
builder.Services.AddTransient<IUsuariosServices, UsuariosServices>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddTransient<IJWTFactory, JWTFactory>();

builder.Services.AddSharedInfrastructure(_configuration);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            //.WithOrigins("aquivatulocalhost_o_dominio_url")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Agregar el esquema de seguridad JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en el formato 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    // Agregar el requisito de seguridad JWT a nivel global
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();