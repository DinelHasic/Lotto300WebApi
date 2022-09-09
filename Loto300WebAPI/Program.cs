
using Loto3000App.Models.Repository;
using Loto3000App.Service;
using Loto3000App.ServiceInterface;
using Loto3000App.Storage.Repository;
using Loto300WebApi.Domain.Repository;
using Loto300WebAPI.Contract.ServiceInterface;
using Loto300WebAPI.Extension;
using Loto300WebAPI.Services;
using Loto300WebAPI.Storage;
using Loto300WebAPI.Storage.Repository;
using Loto300WebAPI.Storage.UnitOfWork;
using Lotto300WebAPI.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string contectionStringDatabase = builder.Configuration.GetConnectionString("Database");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPriceRepository, PriceRepository>()
                .AddScoped<IUserService, UserServices>()
                .AddScoped<IGameServices, GameServices>()
                .AddScoped<ISessionRepository, SessionRepository>()
                .AddScoped<ITicketNumberRepository,TicketNumberRepository>()
                .AddScoped<ILottoDbContextcs, LottoDbContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddSwaggerGen().RegisterDatabase(contectionStringDatabase);



var appConfig = builder.Configuration.GetSection("Auth");

builder.Services.Configure<Auth>(appConfig);

var auth = appConfig.Get<Auth>();
var secret = Encoding.ASCII.GetBytes(auth.SecretKey);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secret)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(action => action.AllowAnyHeader().
                      AllowAnyHeader().
                      AllowAnyMethod().
                      AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
